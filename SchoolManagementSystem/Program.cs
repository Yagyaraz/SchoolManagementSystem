using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.BusinessLayer.Interface;
using SchoolManagementSystem.BusinessLayer.Repository;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Data.Data;
using SchoolManagementSystem.Security;
using System.Text.Json;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SchoolManagementSystemContextConnection") ?? throw new InvalidOperationException("Connection string 'DynamicWebsiteContextConnection' not found.");

//builder.Services.AddDbContext<PlanningContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer((connectionString)), ServiceLifetime.Transient);
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true).AddDefaultTokenProviders().AddDefaultUI().AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString, sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()));

builder.Services.AddAuthentication();

builder.Services.AddMvc(options =>
{
    options.EnableEndpointRouting = false;
    options.Filters.Add(typeof(CustomAuthorizeAttribute));
});
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });
// Register Session services
builder.Services.AddDistributedMemoryCache(); // Required for session storage
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
    options.Cookie.HttpOnly = true; // Enhance security
    options.Cookie.IsEssential = true; // Ensure GDPR compliance
});

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
//User Claims like (Name, post)
//builder.Services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, UserClaimsDetails>();

#region Register
//builder.Services.AddScoped<ICommon, CommonRepository>();
builder.Services.AddScoped<IStudent, StudentRepository>();

#endregion
builder.Services.AddAuthorization();
// Add services to the container.
//builder.Services.AddControllersWithViews();

// added for error 
//builder.Services.Configure<IISServerOptions>(options =>
//{
//    options.MaxRequestBodySize = int.MaxValue;
//});
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    CreateRolesAndAdminUser(scope.ServiceProvider);
    AddRequiredData(scope.ServiceProvider);
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "Contract",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();


#region Create Role and initial User Rergistered
void CreateRolesAndAdminUser(IServiceProvider serviceProvider)
{
    var roleNames = new List<string>
    {
        UserRoles.Administrator,
        UserRoles.SuperAdmin,
        UserRoles.Admin,
        UserRoles.User,
        UserRoles.Student,
        UserRoles.Teacher,
        UserRoles.Parents,
    };

    // Creating roles
    foreach (var role in roleNames)
    {
        CreateRole(serviceProvider, role);
    }

    // Administrator user Setup
    const string administratorUserEmail = "softech@gmail.com";
    const string administratorPwd = "Softech@123!@#";
    AddUserToRole(serviceProvider, new ApplicationUser()
    {
        FullName = UserRoles.Administrator,
        Email = administratorUserEmail,
        UserName = administratorUserEmail,
        EmailConfirmed = true,
        LockoutEnabled = false,
    }, administratorPwd, UserRoles.Administrator);

    // For Super admin 
    const string superAdminUserEmail = "superadmin@gmail.com";
    const string superAdminPwd = "Softech@123";
    AddUserToRole(serviceProvider, new ApplicationUser()
    {
        FullName = UserRoles.SuperAdmin,
        Email = superAdminUserEmail,
        UserName = superAdminUserEmail,
        EmailConfirmed = true,
    }, superAdminPwd, UserRoles.SuperAdmin);
}

void CreateRole(IServiceProvider serviceProvider, string roleName)
{
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roleExists = roleManager.RoleExistsAsync(roleName);
    roleExists.Wait();

    if (roleExists.Result) return;
    var roleResult = roleManager.CreateAsync(new IdentityRole(roleName));
    roleResult.Wait();
}

void AddUserToRole(IServiceProvider serviceProvider, ApplicationUser user, string userPwd, string roleName)
{
    var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    Task<ApplicationUser> checkAppUser = userManager.FindByEmailAsync(user.Email);
    checkAppUser.Wait();

    ApplicationUser appUser = checkAppUser.Result;

    if (checkAppUser.Result == null)
    {
        Task<IdentityResult> taskCreateAppUser = userManager.CreateAsync(user, userPwd);
        taskCreateAppUser.Wait();

        if (taskCreateAppUser.Result.Succeeded)
        {
            appUser = user;
        }
    }
    Task<IdentityResult> newUserRole = userManager.AddToRoleAsync(appUser, roleName);
    newUserRole.Wait();
}
#endregion
#region Add Required Data Before Run Project (Single time Run)
void AddRequiredData(IServiceProvider serviceProvider)
{
    var context = serviceProvider.GetService<ApplicationDbContext>();
    var strategy = context.Database.CreateExecutionStrategy();
    strategy.Execute(() =>
    {
        using (var transaction = context.Database.BeginTransaction())
        {
            try
            {
                #region State
                var states = JsonSerializer.Deserialize<List<States>>(RequiredInitialData.StateJson);
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[State] ON");
                var newStates = states.Where(item => !context.State.Any(x => x.StateId == item.StateId)).ToList();
                context.State.AddRange(newStates);
                context.SaveChanges();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[State] OFF");
                #endregion

                #region District
                var districts = JsonSerializer.Deserialize<List<District>>(RequiredInitialData.DistrictJson);
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[District] ON");
                var newDistricts = districts.Where(item => !context.District.Any(x => x.DistrictId == item.DistrictId)).ToList();
                context.District.AddRange(newDistricts);
                context.SaveChanges();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[District] OFF");
                #endregion

                #region Palika
                var palikas = JsonSerializer.Deserialize<List<Palika>>(RequiredInitialData.PalikaJson);
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Palika] ON");
                var newPalikas = palikas.Where(item => !context.Palika.Any(x => x.PalikaId == item.PalikaId)).ToList();
                context.Palika.AddRange(newPalikas);
                context.SaveChanges();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Palika] OFF");
                #endregion

                #region Project
                var project = new Project { Id = 1, Name = "Cabinet and Administrative Management Information System (CADMIS)", Copyright = "सफ्टेक फाउन्डेसन प्रा.लि" };
                if (!context.Project.Any(x => x.Id == project.Id))
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Project] ON");
                    context.Project.Add(project);
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Project] OFF");
                }
                #endregion

                #region Ward
                var wards = new List<Ward>
                {
                    new() { Id = 1, Name = "गाउँकार्यपालिकाको कार्यालय" },
                    new() { Id = 2, Name = "१ नं वडा कार्यालय" },
                    new() { Id = 3, Name = "२ नं वडा कार्यालय" },
                    new() { Id = 4, Name = "३ नं वडा कार्यालय" },
                    new() { Id = 5, Name = "४ नं वडा कार्यालय" },
                    new() { Id = 6, Name = "५ नं वडा कार्यालय" },
                    new() { Id = 7, Name = "६ नं वडा कार्यालय" },
                };
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Ward] ON");
                var newWards = wards.Where(w => !context.Ward.Any(x => x.Id == w.Id)).ToList();
                context.Ward.AddRange(newWards);
                context.SaveChanges();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Ward] OFF");
                #endregion

            }
            catch (Exception ex)
            {
                app.Logger.LogError($"Error adding required data: {ex.Message}", ex);
                transaction.Rollback();
            }
        }
    });
}
#endregion
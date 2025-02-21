using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using SchoolManagementSystem.Api.Security;
using SchoolManagementSystem.BusinessLayer.Interface;
using SchoolManagementSystem.BusinessLayer.Repositories;
using SchoolManagementSystem.BusinessLayer.Repository;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Data.Data;
using SchoolManagementSystem.Security;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.EnableEndpointRouting = false;
    options.Filters.Add(typeof(CustomAuthorizationAttributes));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authorization with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement { { new OpenApiSecurityScheme { Reference = new OpenApiReference { Id = "Bearer", Type = ReferenceType.SecurityScheme, } }, new List<string>() } });
});
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("SchoolManagementSystemContextConnection") ?? throw new InvalidOperationException("Connection string 'DynamicWebsiteContextConnection' not found.");

//builder.Services.AddDbContext<PlanningContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer((connectionString)), ServiceLifetime.Transient);
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JsonWebTokenKeys:ValidIssuer"],
        ValidAudience = builder.Configuration["JsonWebTokenKeys:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JsonWebTokenKeys:IssuerSigningKey"]))
    };
});
builder.Services.AddAuthorization();
builder.Services.AddScoped<IStudent, StudentRepository>();
builder.Services.AddScoped<IEmployee, EmployeeRepository>();
builder.Services.AddScoped<ICoursePlan, CoursePlanRepository>();
builder.Services.AddScoped<IChapter, ChapterRepository>();
builder.Services.AddScoped<ILessonPlan, LessonPlanRepository>();
builder.Services.AddScoped<ITeachingMethod, TeachingMethodRepository>();

var app = builder.Build();
#region app Related Configration Use
app.Logger.LogInformation("Initialize the app");
//roles and user
using (var scope = app.Services.CreateScope())
{
    CreateRolesAndAdminUser(scope.ServiceProvider);
    //AddRequiredData(scope.ServiceProvider);
}
#endregion
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(options => options
    .WithOrigins(builder.Configuration.GetSection("AllowOrigins").Get<List<string>>().ToArray())
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials());
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
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

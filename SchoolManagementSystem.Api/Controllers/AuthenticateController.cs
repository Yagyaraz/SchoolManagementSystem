using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SchoolManagementSystem.Api.Models;
using SchoolManagementSystem.Data.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolManagementSystem.Api.Controllers
{
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public AuthenticateController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context, IConfiguration configuration)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._context = context;
            this._configuration = configuration;
        }
        //[AllowAnonymous]
        //[HttpGet("/")]
        //public IActionResult Test() => Ok("Welcome To School Management System Api");
        [AllowAnonymous]
        [HttpGet("api/status")]
        public IActionResult Status()
        {
            return Ok(new ApiResponse { Status = true, Message = "Api is running" });
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("api/login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                var userRoles = await _userManager.GetRolesAsync(user);
                var role = userRoles.FirstOrDefault();
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, role),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                var token = new JwtSecurityToken(
                     issuer: _configuration["JsonWebTokenKeys:ValidIssuer"],
                    audience: _configuration["JsonWebTokenKeys:ValidAudience"],
                    claims: authClaims,
                    notBefore: DateTime.UtcNow,
                    expires: DateTime.UtcNow.AddDays(1),
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JsonWebTokenKeys:IssuerSigningKey"])), SecurityAlgorithms.HmacSha256));

                var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                Response.Cookies.Append("jwt", jwtToken, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.None });

                var response = new ApiResponse
                {
                    Status = true,
                    Message = "Login successful! Access granted..!!",
                    Data = new LoginResponse
                    {
                        Name = user.FullName,
                        Role = role,
                        Token = jwtToken,
                        NotBefore = token.ValidFrom,
                        Expiration = token.ValidTo,
                        //IsModelAccess = await _context.AccessControlModel.AnyAsync(x => x.UserId == user.Id),
                        UserId = user.Id,
                        //WardName = await _context.Ward.Where(x => x.Id == user.WardId).Select(x => x.Name).FirstOrDefaultAsync(),
                        //Post = await _context.Employee.Where(x => x.Id == user.EmployeeId).Select(x => x.Post.Name).FirstOrDefaultAsync(),
                    }
                };
                return Ok(response);
            }
            if (result.IsLockedOut)
            {
                return Ok(new ApiResponse() { Status = false, Message = "User account Deactivated !" });
            }
            return Ok(new ApiResponse() { Status = false, Message = "Sorry! invalid credentials.." });
        }
    }
} 
    


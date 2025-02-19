using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.DotNet.MSIdentity.Shared;
using Microsoft.Extensions.Configuration.UserSecrets;
using SchoolManagementSystem.Api.Models;
using SchoolManagementSystem.Data.Data;
using SchoolManagementSystem.Data.Models;
using SchoolManagementSystem.Security;
using System.Security.Claims;

namespace SchoolManagementSystem.Api.Security
{
    public class CustomAuthorizationAttributes:IAsyncAuthorizationFilter
    {
        private readonly ILogger<object> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _context;
        private readonly string userId = null;
        public AuthorizationPolicy Policy { get;}

        public CustomAuthorizationAttributes(ILogger<object>logger,IHttpContextAccessor httpContextAccessor,ApplicationDbContext context)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Policy= new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (context == null)
            {
                throw new ArgumentException(nameof(context));
            }

            var httpContext = context.HttpContext;
            bool isAuthorized = httpContext.User.Identity.IsAuthenticated;
            var fullPath = _httpContextAccessor.HttpContext.Request.Path;
            var splitPath = fullPath.ToString().Split("/");
            var area = splitPath.Count() >= 5 ? splitPath[2] : null;
            var controller = context.RouteData.Values["controller"] ?? "";
            var action = context.RouteData.Values["action"];
            _logger.LogInformation(message: "User Log Date and Time : " + DateTime.UtcNow + " User Id : " + userId + " Url : " + _httpContextAccessor.HttpContext.Request.Host + _httpContextAccessor.HttpContext.Request.Path);

            if (HasAllowAnonymous(context))
                return;

            var policyEvaluator = context.HttpContext.RequestServices.GetRequiredService<IPolicyEvaluator>();
            var authenticateResult = await policyEvaluator.AuthenticateAsync(Policy, context.HttpContext);
            var authorizeResult = await policyEvaluator.AuthorizeAsync(Policy, authenticateResult, context.HttpContext, context);

            var result = Result<string>.Failure("Token Validation Has Failed. Request Access Denied");

            if (isAuthorized)
            {
                if (httpContext.User.IsInRole(UserRoles.Administrator))
                {
                    return;
                }

                if (area != null)
                {
                    if (httpContext.User.IsInRole(UserRoles.User))
                    {
                        context.Result = new JsonResult(result) { StatusCode = StatusCodes.Status401Unauthorized };
                        return;
                    }
                }
                return;
            }
            else
            {
                if (!controller.Equals("Authenticate"))
                    context.Result = new JsonResult(result) { StatusCode = StatusCodes.Status401Unauthorized };
            }

            if (authorizeResult.Challenged)
            {
                context.Result = new JsonResult(result) { StatusCode = StatusCodes.Status401Unauthorized };
            }

            return;
        }


        private static bool HasAllowAnonymous(AuthorizationFilterContext context)
        {
            if (context.Filters.Any(x => x is IAllowAnonymousFilter))
                return true;
            // When doing endpoint routing, MVC does not add AllowAnonymousFilters for AllowAnonymousAttributes that
            // were discovered on controllers and actions. To maintain compat with 2.x,
            // we'll check for the presence of IAllowAnonymous in endpoint metadata.
            var endpoint = context.HttpContext.GetEndpoint();
            if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
            {
                return true;
            }
            return false;
        }
    }
}

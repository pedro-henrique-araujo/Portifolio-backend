using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Portifolio.Auth
{
    public class AuthorizePortifolioFilter :  IAuthorizationFilter
    {
        private readonly IConfiguration _configuration;

        public AuthorizePortifolioFilter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var requestAuthToken = context?.HttpContext?.Request?.Headers?.Authorization.FirstOrDefault();

            var authorizationToken = _configuration.GetValue<string>("AuthorizationToken");
            if (requestAuthToken == authorizationToken) return;

            context.Result = new UnauthorizedObjectResult(string.Empty);
        }
    }

    public class AuthorizePortifolioAttribute : TypeFilterAttribute
    {
        public AuthorizePortifolioAttribute() : base(typeof(AuthorizePortifolioFilter)) {}
    }
}

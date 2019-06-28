using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using RobotApp.Database;


namespace RobotApp.Helpers
{
    public class ContextServiceLocator
    {
        public IRobotRepository RobotRepository => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IRobotRepository>();
        
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContextServiceLocator(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}

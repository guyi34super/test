using Elca.Sms.Api.Domain.Authentication;
using Microsoft.AspNetCore.Http;

namespace Elca.Sms.Api.Service.Authentication 
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IUserSession GetCurrentUser()
        {
            if (_httpContextAccessor?.HttpContext == null)
            {
                return new UserSession();
            }

            IUserSession currentUser = new UserSession
            {
                IsAuthenticated = _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated,
                LoginName = _httpContextAccessor.HttpContext.User.Identity.Name
            };

            return currentUser;
        }
    }
}
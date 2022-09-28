using Elca.Sms.Api.Domain.Authentication;

namespace Elca.Sms.Api.Service.Authentication
{
    public interface ICurrentUserService
    {
        IUserSession GetCurrentUser();
    }
}

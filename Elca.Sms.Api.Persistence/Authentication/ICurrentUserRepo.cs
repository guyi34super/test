using Elca.Sms.Api.Domain.Authentication;

namespace Elca.Sms.Api.Persistence.Authentication
{
    public interface ICurrentUserRepo
    {
        IUserSession GetCurrentUser();
    }
}


namespace Elca.Sms.Api.Domain.Authentication
{
    public class UserSession : IUserSession
    {
        public string LoginName { get; set; }

        public bool IsAuthenticated { get; set; }
    }
}
namespace Elca.Sms.Api.Domain.Authentication
{
    public interface IUserSession
    {
        string LoginName { get; set; }

        bool IsAuthenticated { get; set; }
    }
}

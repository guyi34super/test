using Elca.Sms.Api.Domain.Entity;
namespace Elca.Sms.Api.Domain.Communication
{
    public class RequestorResponse : BaseResponse
    {
        public Requestor Requestor { get; private set; }

        private RequestorResponse(bool success, string message, Requestor requestor) : base(success, message)
        {
            Requestor = requestor;
        }
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="requestor">Saved order.</param> 
        /// <returns>Response.</returns>
        public RequestorResponse(Requestor requestor) : this(true, string.Empty, requestor)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public RequestorResponse(string message) : this(false, message, null)
        { }
    }
}

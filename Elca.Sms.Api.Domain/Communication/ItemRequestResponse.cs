using Elca.Sms.Api.Domain.Entity;


namespace Elca.Sms.Api.Domain.Communication
{
    public class ItemRequestResponse : BaseResponse
    {
        public ItemRequest ItemRequest { get; private set; }

        private ItemRequestResponse(bool success, string message, ItemRequest itemRequest) : base(success, message)
        {
            ItemRequest = itemRequest;
        }
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="itemRequest">Saved order.</param>
        /// <returns>Response.</returns>
        public ItemRequestResponse(ItemRequest itemRequest) : this(true, string.Empty, itemRequest)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public ItemRequestResponse(string message) : this(false, message, null)
        { }
    }
}

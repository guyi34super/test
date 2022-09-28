using Elca.Sms.Api.Domain.Entity;

namespace Elca.Sms.Api.Domain.Communication
{
    public class OrderItemResponse : BaseResponse
    {
        public OrderItem  OrderItem { get; private set; }

        private OrderItemResponse(bool success, string message, OrderItem orderItem) : base(success, message)
        {
            OrderItem = orderItem;
        }
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="orderItem">Saved order.</param>
        /// <returns>Response.</returns>
        public OrderItemResponse(OrderItem orderItem) : this(true, string.Empty, orderItem)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public OrderItemResponse(string message) : this(false, message, null)
        { }
    }
}

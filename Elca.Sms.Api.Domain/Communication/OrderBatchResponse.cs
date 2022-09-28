using Elca.Sms.Api.Domain.Entity;

namespace Elca.Sms.Api.Domain.Communication
{
    public class OrderBatchResponse : BaseResponse
    {
        public OrderBatch OrderBatch { get; private set; }

        private OrderBatchResponse(bool success, string message, OrderBatch orderBatch) : base(success, message)
        {
            OrderBatch = orderBatch;
        }
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="orderBatch">Saved order.</param>
        /// <returns>Response.</returns>
        public OrderBatchResponse(OrderBatch orderBatch) : this(true, string.Empty, orderBatch)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public OrderBatchResponse(string message) : this(false, message, null) 
        { }
    }
}

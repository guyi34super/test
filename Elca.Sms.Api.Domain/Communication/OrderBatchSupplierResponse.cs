using Elca.Sms.Api.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elca.Sms.Api.Domain.Communication
{
    public class OrderBatchSupplierResponse : BaseResponse
    {
        public OrderBatchSupplier OrderBatchSupplier { get; private set; }

        private OrderBatchSupplierResponse(bool success, string message, OrderBatchSupplier orderBatchSupplier) : base(success, message)
        {
            OrderBatchSupplier = orderBatchSupplier;
        }
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="orderBatchSupplier">Saved order.</param>
        /// <returns>Response.</returns>
        public OrderBatchSupplierResponse(OrderBatchSupplier orderBatchSupplier) : this(true, string.Empty, orderBatchSupplier)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public OrderBatchSupplierResponse(string message) : this(false, message, null)
        { }
    }
}

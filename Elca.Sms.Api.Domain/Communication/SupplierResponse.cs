using Elca.Sms.Api.Domain.Entity;

namespace Elca.Sms.Api.Domain.Communication
{
    public class SupplierResponse : BaseResponse    
    {
        public Supplier Supplier { get; private set; }

        private SupplierResponse(bool success, string message, Supplier supplier) : base(success, message)
        {
            Supplier = supplier;
        }
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="supplier">Saved order.</param>
        /// <returns>Response.</returns>
        public SupplierResponse(Supplier supplier) : this(true, string.Empty, supplier)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SupplierResponse(string message) : this(false, message, null) 
        { }
    }
}

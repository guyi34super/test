using Elca.Sms.Api.Domain.Entity;

namespace Elca.Sms.Api.Domain.Communication
{
    public class ProductTypeResponse : BaseResponse
    {
        public ProductType ProductType { get; private set; }

        private ProductTypeResponse(bool success, string message, ProductType productType) : base(success, message)
        {
            ProductType = productType;
        }
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="productType">Saved order.</param>
        /// <returns>Response.</returns>
        public ProductTypeResponse(ProductType productType) : this(true, string.Empty, productType) 
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public ProductTypeResponse(string message) : this(false, message, null)
        { }
    }
}

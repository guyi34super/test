using Elca.Sms.Api.Domain.Entity;

namespace Elca.Sms.Api.Domain.Communication
{
    public class ProductItemResponse : BaseResponse
    {
        public ProductItem ProductItem { get; private set; }

        private ProductItemResponse(bool success, string message, ProductItem productItem) : base(success, message)
        {
            ProductItem = productItem;
        }
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="productItem">Saved order.</param>
        /// <returns>Response.</returns>
        public ProductItemResponse(ProductItem productItem) : this(true, string.Empty, productItem)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public ProductItemResponse(string message) : this(false, message, null)
        { }
    }
}

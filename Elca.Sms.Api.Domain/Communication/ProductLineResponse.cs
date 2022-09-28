using Elca.Sms.Api.Domain.Entity;

namespace Elca.Sms.Api.Domain.Communication
{
    public class ProductLineResponse : BaseResponse
    {
        public ProductLine ProductLine { get; private set; }

        private ProductLineResponse(bool success, string message, ProductLine productLine) : base(success, message)
        {
            ProductLine = productLine;
        }
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="productLine">Saved order.</param>
        /// <returns>Response.</returns>
        public ProductLineResponse(ProductLine productLine) : this(true, string.Empty, productLine)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public ProductLineResponse(string message) : this(false, message, null)
        { }
    }
}

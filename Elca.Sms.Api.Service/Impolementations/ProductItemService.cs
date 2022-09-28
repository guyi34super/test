using Elca.Sms.Api.Domain.Communication;
using Elca.Sms.Api.Domain.Entity;
using Elca.Sms.Api.Persistence.Interfaces;
using Elca.Sms.Api.Service.Interfaces;
using System.Linq.Expressions;

namespace Elca.Sms.Api.Service.Impolementations
{
    public class ProductItemService : IProductItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductItemService(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }
        public async Task<ProductItemResponse> DeleteAsync(int id)
        {
            var existingProductItemId = await _unitOfWork.ProductItems.GetAsync(id);


            if (existingProductItemId == null)
                return new ProductItemResponse("ProductItem not found.");

            try
            {
                _unitOfWork.ProductItems.DeleteSync(existingProductItemId);
                await _unitOfWork.CompleteAsync();

                return new ProductItemResponse(existingProductItemId);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ProductItemResponse($"An error occurred when updating the ProductItem: {ex.Message}");
            }
        }

        public IEnumerable<ProductItem> Find(Expression<Func<ProductItem, bool>> predicate)
        {

            throw new NotImplementedException();
        }

        public async Task<ProductItem> GetAsync(int id)
        {
            return await _unitOfWork.ProductItems.GetAsync(id);
        }

        public async Task<IEnumerable<ProductItem>> ListAsync()
        {
            return await _unitOfWork.ProductItems.ListAsync();
        }

        public async Task<ProductItemResponse> PostAsync(ProductItem tEntity)
        {
            try
            {
                await _unitOfWork.ProductItems.AddSync(tEntity);
                await _unitOfWork.CompleteAsync();

                return new ProductItemResponse(tEntity);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ProductItemResponse($"An error occurred when saving the ProductItem: {ex.Message}");
            }
        }

        public async Task<ProductItemResponse> UpdateAsync(int id, ProductItem tEntity)
        {
            var existingProductItem = await _unitOfWork.ProductItems.GetAsync(id);


            if (existingProductItem == null)
                return new ProductItemResponse("ProductItem not found.");

            //existingProductItem.LastName = tEntity.LastName;
            //existingProductItem.OtherNames = tEntity.OtherNames;
            //existingProductItem.DateLastModified = DateTime.Now;

            try
            {
                await _unitOfWork.CompleteAsync();
                return new ProductItemResponse(tEntity);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ProductItemResponse($"An error occurred when updating the course: {ex.Message}");
            }
        }
    }
}
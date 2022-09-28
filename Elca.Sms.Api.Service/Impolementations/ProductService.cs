using Elca.Sms.Api.Domain.Communication;
using Elca.Sms.Api.Domain.Entity;
using Elca.Sms.Api.Persistence.Interfaces;
using Elca.Sms.Api.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Elca.Sms.Api.Service.Impolementations
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }
        public async Task<ProductResponse> DeleteAsync(int id)
        {
            var existingProductItemId = await _unitOfWork.Products.GetAsync(id);


            if (existingProductItemId == null)
                return new ProductResponse("Product not found.");

            try
            {
                _unitOfWork.Products.DeleteSync(existingProductItemId);
                await _unitOfWork.CompleteAsync();

                return new ProductResponse(existingProductItemId);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ProductResponse($"An error occurred when updating the Product: {ex.Message}");
            }
        }

        public IEnumerable<Product> Find(Expression<Func<Product, bool>> predicate)
        {

            throw new NotImplementedException();
        }

        public async Task<Product> GetAsync(int id)
        {
            return await _unitOfWork.Products.GetAsync(id);
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _unitOfWork.Products.ListAsync();
        }

        public async Task<ProductResponse> PostAsync(Product tEntity)
        {
            try
            {
                await _unitOfWork.Products.AddSync(tEntity);
                await _unitOfWork.CompleteAsync();

                return new ProductResponse(tEntity);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ProductResponse($"An error occurred when saving the Product: {ex.Message}");
            }
        }

        public async Task<ProductResponse> UpdateAsync(int id, Product tEntity)
        {
            var existingProduct = await _unitOfWork.Products.GetAsync(id);


            if (existingProduct == null)
                return new ProductResponse("Product not found.");

            //existingProduct.LastName = tEntity.LastName;
            //existingProduct.OtherNames = tEntity.OtherNames;
            //existingProduct.DateLastModified = DateTime.Now;

            try
            {
                await _unitOfWork.CompleteAsync();
                return new ProductResponse(tEntity);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ProductResponse($"An error occurred when updating the course: {ex.Message}");
            }
        }
    }
}
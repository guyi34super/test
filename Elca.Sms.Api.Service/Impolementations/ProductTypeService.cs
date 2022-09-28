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
    public class ProductTypeService : IProductTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductTypeService(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }
        public async Task<ProductTypeResponse> DeleteAsync(int id)
        {
            var existingProductItemId = await _unitOfWork.ProductTypes.GetAsync(id);


            if (existingProductItemId == null)
                return new ProductTypeResponse("ProductType not found.");

            try
            {
                _unitOfWork.ProductTypes.DeleteSync(existingProductItemId);
                await _unitOfWork.CompleteAsync();

                return new ProductTypeResponse(existingProductItemId);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ProductTypeResponse($"An error occurred when updating the ProductType: {ex.Message}");
            }
        }

        public IEnumerable<ProductType> Find(Expression<Func<ProductType, bool>> predicate)
        {

            throw new NotImplementedException();
        }

        public async Task<ProductType> GetAsync(int id)
        {
            return await _unitOfWork.ProductTypes.GetAsync(id);
        }

        public async Task<IEnumerable<ProductType>> ListAsync()
        {
            return await _unitOfWork.ProductTypes.ListAsync();
        }

        public async Task<ProductTypeResponse> PostAsync(ProductType tEntity)
        {
            try
            {
                await _unitOfWork.ProductTypes.AddSync(tEntity);
                await _unitOfWork.CompleteAsync();

                return new ProductTypeResponse(tEntity);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ProductTypeResponse($"An error occurred when saving the ProductType: {ex.Message}");
            }
        }

        public async Task<ProductTypeResponse> UpdateAsync(int id, ProductType tEntity)
        {
            var existingProductType = await _unitOfWork.ProductTypes.GetAsync(id);


            if (existingProductType == null)
                return new ProductTypeResponse("ProductType not found.");

            //existingProductType.LastName = tEntity.LastName;
            //existingProductType.OtherNames = tEntity.OtherNames;
            //existingProductType.DateLastModified = DateTime.Now;

            try
            {
                await _unitOfWork.CompleteAsync();
                return new ProductTypeResponse(tEntity);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ProductTypeResponse($"An error occurred when updating the course: {ex.Message}");
            }
        }
    }
}
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
    public class ProductLineService : IProductLineService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductLineService(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }
        public async Task<ProductLineResponse> DeleteAsync(int id)
        {
            var existingProductItemId = await _unitOfWork.ProductLines.GetAsync(id);


            if (existingProductItemId == null)
                return new ProductLineResponse("ProductLine not found.");

            try
            {
                _unitOfWork.ProductLines.DeleteSync(existingProductItemId);
                await _unitOfWork.CompleteAsync();

                return new ProductLineResponse(existingProductItemId);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ProductLineResponse($"An error occurred when updating the ProductLine: {ex.Message}");
            }
        }

        public IEnumerable<ProductLine> Find(Expression<Func<ProductLine, bool>> predicate)
        {

            throw new NotImplementedException();
        }

        public async Task<ProductLine> GetAsync(int id)
        {
            return await _unitOfWork.ProductLines.GetAsync(id);
        }

        public async Task<IEnumerable<ProductLine>> ListAsync()
        {
            return await _unitOfWork.ProductLines.ListAsync();
        }

        public async Task<ProductLineResponse> PostAsync(ProductLine tEntity)
        {
            try
            {
                await _unitOfWork.ProductLines.AddSync(tEntity);
                await _unitOfWork.CompleteAsync();

                return new ProductLineResponse(tEntity);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ProductLineResponse($"An error occurred when saving the ProductLine: {ex.Message}");
            }
        }

        public async Task<ProductLineResponse> UpdateAsync(int id, ProductLine tEntity)
        {
            var existingProductLine = await _unitOfWork.ProductLines.GetAsync(id);


            if (existingProductLine == null)
                return new ProductLineResponse("ProductLine not found.");

            //existingProductLine.LastName = tEntity.LastName;
            //existingProductLine.OtherNames = tEntity.OtherNames;
            //existingProductLine.DateLastModified = DateTime.Now;

            try
            {
                await _unitOfWork.CompleteAsync();
                return new ProductLineResponse(tEntity);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ProductLineResponse($"An error occurred when updating the course: {ex.Message}");
            }
        }
    }
}
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
    public class OrderBatchSupplierService : IOrderBatchSupplierService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderBatchSupplierService(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }
        public async Task<OrderBatchSupplierResponse> DeleteAsync(int id)
        {
            var existingItemRequestId = await _unitOfWork.OrderBatchSuppliers.GetAsync(id);


            if (existingItemRequestId == null)
                return new OrderBatchSupplierResponse("OrderBatchSupplier not found.");

            try
            {
                _unitOfWork.OrderBatchSuppliers.DeleteSync(existingItemRequestId);
                await _unitOfWork.CompleteAsync();

                return new OrderBatchSupplierResponse(existingItemRequestId);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new OrderBatchSupplierResponse($"An error occurred when updating the OrderBatchSupplier: {ex.Message}");
            }
        }

        public IEnumerable<OrderBatchSupplier> Find(Expression<Func<OrderBatchSupplier, bool>> predicate)
        {

            throw new NotImplementedException();
        }

        public async Task<OrderBatchSupplier> GetAsync(int id)
        {
            return await _unitOfWork.OrderBatchSuppliers.GetAsync(id);
        }

        public async Task<IEnumerable<OrderBatchSupplier>> ListAsync()
        {
            return await _unitOfWork.OrderBatchSuppliers.ListAsync();
        }

        public async Task<OrderBatchSupplierResponse> PostAsync(OrderBatchSupplier tEntity)
        {
            try
            {
                await _unitOfWork.OrderBatchSuppliers.AddSync(tEntity);
                await _unitOfWork.CompleteAsync();

                return new OrderBatchSupplierResponse(tEntity);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new OrderBatchSupplierResponse($"An error occurred when saving the OrderBatchSupplier: {ex.Message}");
            }
        }

        public async Task<OrderBatchSupplierResponse> UpdateAsync(int id, OrderBatchSupplier tEntity)
        {
            var existingOrderBatchSupplier = await _unitOfWork.OrderBatchSuppliers.GetAsync(id);


            if (existingOrderBatchSupplier == null)
                return new OrderBatchSupplierResponse("OrderBatchSupplier not found.");

            //existingOrderBatchSupplier.LastName = tEntity.LastName;
            //existingOrderBatchSupplier.OtherNames = tEntity.OtherNames;
            //existingOrderBatchSupplier.DateLastModified = DateTime.Now;

            try
            {
                await _unitOfWork.CompleteAsync();
                return new OrderBatchSupplierResponse(tEntity);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new OrderBatchSupplierResponse($"An error occurred when updating the course: {ex.Message}");
            }
        }
    }
}
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
    public class OrderBatchService : IOrderBatchService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderBatchService(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }
        public async Task<OrderBatchResponse> DeleteAsync(int id)
        {
            var existingOrderBatchId = await _unitOfWork.OrderBatches.GetAsync(id);


            if (existingOrderBatchId == null)
                return new OrderBatchResponse("OrderBatch not found.");

            try
            {
                _unitOfWork.OrderBatches.DeleteSync(existingOrderBatchId);
                await _unitOfWork.CompleteAsync();

                return new OrderBatchResponse(existingOrderBatchId);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new OrderBatchResponse($"An error occurred when updating the OrderBatch: {ex.Message}");
            }
        }

        public IEnumerable<OrderBatch> Find(Expression<Func<OrderBatch, bool>> predicate)
        {

            throw new NotImplementedException();
        }

        public async Task<OrderBatch> GetAsync(int id)
        {
            return await _unitOfWork.OrderBatches.GetAsync(id);
        }

        public async Task<IEnumerable<OrderBatch>> ListAsync()
        {
            return await _unitOfWork.OrderBatches.ListAsync();
        }

        public async Task<OrderBatchResponse> PostAsync(OrderBatch tEntity)
        {
            try
            {
                await _unitOfWork.OrderBatches.AddSync(tEntity);
                await _unitOfWork.CompleteAsync();

                return new OrderBatchResponse(tEntity);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new OrderBatchResponse($"An error occurred when saving the OrderBatch: {ex.Message}");
            }
        }

        public async Task<OrderBatchResponse> UpdateAsync(int id, OrderBatch tEntity)
        {
            var existingOrderBatch = await _unitOfWork.OrderBatches.GetAsync(id);


            if (existingOrderBatch == null)
                return new OrderBatchResponse("OrderBatch not found.");

            //existingOrderBatch.LastName = tEntity.LastName;
            //existingOrderBatch.OtherNames = tEntity.OtherNames;
            //existingOrderBatch.DateLastModified = DateTime.Now;

            try
            {
                await _unitOfWork.CompleteAsync();
                return new OrderBatchResponse(tEntity);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new OrderBatchResponse($"An error occurred when updating the course: {ex.Message}");
            }
        }
    }
}
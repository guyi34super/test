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
    public class OrderItemService : IOrderItemService  
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderItemService(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }
        public async Task<OrderItemResponse> DeleteAsync(int id)
        {
            var existingOrderBatchId = await _unitOfWork.OrderItems.GetAsync(id);


            if (existingOrderBatchId == null)
                return new OrderItemResponse("OrderItem not found.");

            try
            {
                _unitOfWork.OrderItems.DeleteSync(existingOrderBatchId);
                await _unitOfWork.CompleteAsync();

                return new OrderItemResponse(existingOrderBatchId);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new OrderItemResponse($"An error occurred when updating the OrderItem: {ex.Message}");
            }
        }

        public IEnumerable<OrderItem> Find(Expression<Func<OrderItem, bool>> predicate)
        {

            throw new NotImplementedException();
        }

        public async Task<OrderItem> GetAsync(int id)
        {
            return await _unitOfWork.OrderItems.GetAsync(id);
        }

        public async Task<IEnumerable<OrderItem>> ListAsync()
        {
            return await _unitOfWork.OrderItems.ListAsync();
        }

        public async Task<OrderItemResponse> PostAsync(OrderItem tEntity)
        {
            try
            {
                await _unitOfWork.OrderItems.AddSync(tEntity);
                await _unitOfWork.CompleteAsync();

                return new OrderItemResponse(tEntity);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new OrderItemResponse($"An error occurred when saving the OrderItem: {ex.Message}");
            }
        }

        public async Task<OrderItemResponse> UpdateAsync(int id, OrderItem tEntity)
        {
            var existingOrderItem = await _unitOfWork.OrderItems.GetAsync(id);


            if (existingOrderItem == null)
                return new OrderItemResponse("OrderItem not found.");

            //existingOrderItem.LastName = tEntity.LastName;
            //existingOrderItem.OtherNames = tEntity.OtherNames;
            //existingOrderItem.DateLastModified = DateTime.Now;

            try
            {
                await _unitOfWork.CompleteAsync();
                return new OrderItemResponse(tEntity);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new OrderItemResponse($"An error occurred when updating the course: {ex.Message}");
            }
        }
    }
}
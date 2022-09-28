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
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }
        public async Task<OrderResponse> DeleteAsync(int id)
        {
            var existingOrderBatchId = await _unitOfWork.Orders.GetAsync(id);


            if (existingOrderBatchId == null)
                return new OrderResponse("Order not found.");

            try
            {
                _unitOfWork.Orders.DeleteSync(existingOrderBatchId);
                await _unitOfWork.CompleteAsync();

                return new OrderResponse(existingOrderBatchId);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new OrderResponse($"An error occurred when updating the Order: {ex.Message}");
            }
        }

        public IEnumerable<Order> Find(Expression<Func<Order, bool>> predicate)
        {

            throw new NotImplementedException();
        }

        public async Task<Order> GetAsync(int id)
        {
            return await _unitOfWork.Orders.GetAsync(id);
        }

        public async Task<IEnumerable<Order>> ListAsync()
        {
            return await _unitOfWork.Orders.ListAsync();
        }

        public async Task<OrderResponse> PostAsync(Order tEntity)
        {
            try
            {
                await _unitOfWork.Orders.AddSync(tEntity);
                await _unitOfWork.CompleteAsync();

                return new OrderResponse(tEntity);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new OrderResponse($"An error occurred when saving the Order: {ex.Message}");
            }
        }

        public async Task<OrderResponse> UpdateAsync(int id, Order tEntity)
        {
            var existingOrder = await _unitOfWork.Orders.GetAsync(id);


            if (existingOrder == null)
                return new OrderResponse("Order not found.");

            //existingOrder.LastName = tEntity.LastName;
            //existingOrder.OtherNames = tEntity.OtherNames;
            //existingOrder.DateLastModified = DateTime.Now;

            try
            {
                await _unitOfWork.CompleteAsync();
                return new OrderResponse(tEntity);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new OrderResponse($"An error occurred when updating the course: {ex.Message}");
            }
        }
    }
}
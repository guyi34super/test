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
    public class ItemRequestService : IItemRequestService 
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemRequestService(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }
        public async Task<ItemRequestResponse> DeleteAsync(int id)
        {
            var existingItemRequestId = await _unitOfWork.ItemRequests.GetAsync(id);


            if (existingItemRequestId == null)
                return new ItemRequestResponse("ItemRequest not found.");

            try
            {
                _unitOfWork.ItemRequests.DeleteSync(existingItemRequestId);
                await _unitOfWork.CompleteAsync();

                return new ItemRequestResponse(existingItemRequestId);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ItemRequestResponse($"An error occurred when updating the ItemRequest: {ex.Message}");
            }
        }

        public IEnumerable<ItemRequest> Find(Expression<Func<ItemRequest, bool>> predicate)
        {

            throw new NotImplementedException();
        }

        public async Task<ItemRequest> GetAsync(int id)
        {
            return await _unitOfWork.ItemRequests.GetAsync(id);
        }

        public async Task<IEnumerable<ItemRequest>> ListAsync()
        {
            return await _unitOfWork.ItemRequests.ListAsync();
        }

        public async Task<ItemRequestResponse> PostAsync(ItemRequest tEntity)
        {
            try
            {
                await _unitOfWork.ItemRequests.AddSync(tEntity);
                await _unitOfWork.CompleteAsync();

                return new ItemRequestResponse(tEntity);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ItemRequestResponse($"An error occurred when saving the ItemRequest: {ex.Message}");
            }
        }

        public async Task<ItemRequestResponse> UpdateAsync(int id, ItemRequest tEntity)
        {
            var existingItemRequest = await _unitOfWork.ItemRequests.GetAsync(id);


            if (existingItemRequest == null)
                return new ItemRequestResponse("ItemRequest not found.");

            //existingItemRequest.LastName = tEntity.LastName;
            //existingItemRequest.OtherNames = tEntity.OtherNames;
            //existingItemRequest.DateLastModified = DateTime.Now;

            try
            {
                await _unitOfWork.CompleteAsync();
                return new ItemRequestResponse(tEntity);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ItemRequestResponse($"An error occurred when updating the course: {ex.Message}");
            }
        }
    }
}
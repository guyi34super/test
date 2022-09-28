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
    public class RequestorService : IRequestorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RequestorService(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }
        public async Task<RequestorResponse> DeleteAsync(int id)
        {
            var existingRequestorId = await _unitOfWork.Requestors.GetAsync(id);


            if (existingRequestorId == null)
                return new RequestorResponse("Requestor not found.");

            try
            {
                _unitOfWork.Requestors.DeleteSync(existingRequestorId);
                await _unitOfWork.CompleteAsync();

                return new RequestorResponse(existingRequestorId);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new RequestorResponse($"An error occurred when updating the Requestor: {ex.Message}");
            }
        }

        public IEnumerable<Requestor> Find(Expression<Func<Requestor, bool>> predicate)
        {

            throw new NotImplementedException();
        }

        public async Task<Requestor> GetAsync(int id)
        {
            return await _unitOfWork.Requestors.GetAsync(id);
        }

        public async Task<IEnumerable<Requestor>> ListAsync()
        {
            return await _unitOfWork.Requestors.ListAsync();
        }

        public async Task<RequestorResponse> PostAsync(Requestor tEntity)
        {
            try
            {
                await _unitOfWork.Requestors.AddSync(tEntity);
                await _unitOfWork.CompleteAsync();

                return new RequestorResponse(tEntity);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new RequestorResponse($"An error occurred when saving the Requestor: {ex.Message}");
            }
        }

        public async Task<RequestorResponse> UpdateAsync(int id, Requestor tEntity)
        {
            var existingRequestor = await _unitOfWork.Requestors.GetAsync(id);


            if (existingRequestor == null)
                return new RequestorResponse("Requestor not found.");

            //existingRequestor.LastName = tEntity.LastName;
            //existingRequestor.OtherNames = tEntity.OtherNames;
            //existingRequestor.DateLastModified = DateTime.Now;

            try
            {
                await _unitOfWork.CompleteAsync();
                return new RequestorResponse(tEntity);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new RequestorResponse($"An error occurred when updating the course: {ex.Message}");
            }
        }
    }
}
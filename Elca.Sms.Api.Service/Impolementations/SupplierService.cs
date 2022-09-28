using Elca.Sms.Api.Domain.Communication;
using Elca.Sms.Api.Domain.Entity;
using Elca.Sms.Api.Persistence.Interfaces;
using Elca.Sms.Api.Service.Interfaces;

using System.Linq.Expressions;


namespace Elca.Sms.Api.Service.Impolementations
{
    public class SupplierService : ISupplierService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SupplierService(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }
        public async Task<SupplierResponse> DeleteAsync(int id)
        {
            var existingSupplierId = await _unitOfWork.Suppliers.GetAsync(id);


            if (existingSupplierId == null)
                return new SupplierResponse("Supplier not found.");

            try
            {
                _unitOfWork.Suppliers.DeleteSync(existingSupplierId);
                await _unitOfWork.CompleteAsync();

                return new SupplierResponse(existingSupplierId);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SupplierResponse($"An error occurred when updating the Supplier: {ex.Message}");
            }
        }

        public IEnumerable<Supplier> Find(Expression<Func<Supplier, bool>> predicate)
        {

            throw new NotImplementedException();
        }

        public async Task<Supplier> GetAsync(int id)
        {
            return await _unitOfWork.Suppliers.GetAsync(id);
        }

        public async Task<IEnumerable<Supplier>> ListAsync()
        {
            return await _unitOfWork.Suppliers.ListAsync();
        }

        public async Task<SupplierResponse> PostAsync(Supplier tEntity)
        {
            try
            {
                await _unitOfWork.Suppliers.AddSync(tEntity);
                await _unitOfWork.CompleteAsync();

                return new SupplierResponse(tEntity);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SupplierResponse($"An error occurred when saving the Supplier: {ex.Message}");
            }
        }

        public async Task<SupplierResponse> UpdateAsync(int id, Supplier tEntity)
        {
            var existingRequestor = await _unitOfWork.Suppliers.GetAsync(id);


            if (existingRequestor == null)
                return new SupplierResponse("Supplier not found.");

            //existingRequestor.LastName = tEntity.LastName;
            //existingRequestor.OtherNames = tEntity.OtherNames;
            //existingRequestor.DateLastModified = DateTime.Now;

            try
            {
                await _unitOfWork.CompleteAsync();
                return new SupplierResponse(tEntity);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SupplierResponse($"An error occurred when updating the course: {ex.Message}");
            }
        }
    }
}
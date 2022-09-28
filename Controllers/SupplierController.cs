using AutoMapper;
using Elca.Sms.Api.Domain.Entity;
using Elca.Sms.Api.Service.Interfaces;
using ELCAStock.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ELCAStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;
        public SupplierController(ISupplierService supplierService, IMapper mapper)
        {
            _supplierService = supplierService;
            _mapper = mapper;
        }
        // GET: api/Employees
        [HttpGet]
        public async Task<IEnumerable<SupplierDTO>> GetAllAsync()
        {
            var Supplier = await _supplierService.ListAsync();
            var SupplierDTO = _mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierDTO>>(Supplier);

            return SupplierDTO;
        }

        // GET: api/Resignees/5
        [HttpGet("{id}")]
        public async Task<SupplierDTO> GetAsync(int id)
        {

            var Supplier = await _supplierService.GetAsync(id);
            var SupplierDTO = _mapper.Map<Supplier, SupplierDTO>(Supplier);
            return SupplierDTO;

        }

        // POST: api/Resignees
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SupplierDTO supplierDTO)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState.GetErrorMessages());

            var supplier = _mapper.Map<SupplierDTO, Supplier>(supplierDTO);
            var result = await _supplierService.PostAsync(supplier);

            if (!result.Success)
                return BadRequest(result.Message);

            supplierDTO = _mapper.Map<Supplier, SupplierDTO>(result.Supplier);
            return Ok(supplierDTO);
        }

        // PUT: api/Resignees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SupplierDTO supplierDTO)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState.GetErrorMessages());

            var supplier = _mapper.Map<SupplierDTO, Supplier>(supplierDTO);
            var result = await _supplierService.UpdateAsync(id, supplier);

            if (!result.Success)
                return BadRequest(result.Message);

            supplierDTO = _mapper.Map<Supplier, SupplierDTO>(result.Supplier);
            return Ok(supplierDTO);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _supplierService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var supplierDTO = _mapper.Map<Supplier, SupplierDTO>(result.Supplier);
            return Ok(supplierDTO);
        }
    }
}

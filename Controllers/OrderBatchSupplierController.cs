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
    public class OrderBatchSupplierController : ControllerBase
    {
        private readonly IOrderBatchSupplierService _orderBatchSupplierService;
        private readonly IMapper _mapper;
        public OrderBatchSupplierController(IOrderBatchSupplierService orderBatchSupplierService, IMapper mapper)
        {
            _orderBatchSupplierService = orderBatchSupplierService;
            _mapper = mapper;
        }
        // GET: api/Employees
        [HttpGet]
        public async Task<IEnumerable<OrderBatchSupplierDTO>> GetAllAsync()
        {
            var OrderBatchSupplier = await _orderBatchSupplierService.ListAsync();
            var OrderBatchSupplierDTO = _mapper.Map<IEnumerable<OrderBatchSupplier>, IEnumerable<OrderBatchSupplierDTO>>(OrderBatchSupplier);

            return OrderBatchSupplierDTO;
        }

        // GET: api/Resignees/5
        [HttpGet("{id}")]
        public async Task<OrderBatchSupplierDTO> GetAsync(int id)
        {

            var OrderBatchSupplier = await _orderBatchSupplierService.GetAsync(id);
            var OrderBatchSupplierDTO = _mapper.Map<OrderBatchSupplier, OrderBatchSupplierDTO>(OrderBatchSupplier);
            return OrderBatchSupplierDTO;

        }

        // POST: api/Resignees
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] OrderBatchSupplierDTO orderBatchSupplierDTO)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState.GetErrorMessages());

            var requestor = _mapper.Map<OrderBatchSupplierDTO, OrderBatchSupplier>(orderBatchSupplierDTO);
            var result = await _orderBatchSupplierService.PostAsync(requestor);

            if (!result.Success)
                return BadRequest(result.Message);

            orderBatchSupplierDTO = _mapper.Map<OrderBatchSupplier, OrderBatchSupplierDTO>(result.OrderBatchSupplier);
            return Ok(orderBatchSupplierDTO);
        }

        // PUT: api/Resignees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] OrderBatchSupplierDTO orderBatchSupplierDTO)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState.GetErrorMessages());

            var requestor = _mapper.Map<OrderBatchSupplierDTO, OrderBatchSupplier>(orderBatchSupplierDTO);
            var result = await _orderBatchSupplierService.UpdateAsync(id, requestor);

            if (!result.Success)
                return BadRequest(result.Message);

            orderBatchSupplierDTO = _mapper.Map<OrderBatchSupplier, OrderBatchSupplierDTO>(result.OrderBatchSupplier);
            return Ok(orderBatchSupplierDTO);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _orderBatchSupplierService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var orderBatchSupplierDTO = _mapper.Map<OrderBatchSupplier, OrderBatchSupplierDTO>(result.OrderBatchSupplier);
            return Ok(orderBatchSupplierDTO);
        }
    }
}

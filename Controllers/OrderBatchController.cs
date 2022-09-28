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
    public class OrderBatchController : ControllerBase
    {
        private readonly IOrderBatchService _orderBatchService; 
        private readonly IMapper _mapper;
        public OrderBatchController(IOrderBatchService orderBatchService, IMapper mapper)
        {
            _orderBatchService = orderBatchService;
            _mapper = mapper;
        }
        // GET: api/Employees
        [HttpGet]
        public async Task<IEnumerable<OrderBatchDTO>> GetAllAsync()
        {
            var OrderBatch = await _orderBatchService.ListAsync();
            var OrderBatchDTO = _mapper.Map<IEnumerable<OrderBatch>, IEnumerable<OrderBatchDTO>>(OrderBatch);

            return OrderBatchDTO;
        }

        // GET: api/Resignees/5
        [HttpGet("{id}")]
        public async Task<OrderBatchDTO> GetAsync(int id)
        {

            var OrderBatch = await _orderBatchService.GetAsync(id);
            var OrderBatchDTO = _mapper.Map<OrderBatch, OrderBatchDTO>(OrderBatch);
            return OrderBatchDTO;

        }

        // POST: api/Resignees
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] OrderBatchDTO orderBatchDTO)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState.GetErrorMessages());

            var orderBatch = _mapper.Map<OrderBatchDTO, OrderBatch>(orderBatchDTO);
            var result = await _orderBatchService.PostAsync(orderBatch);

            if (!result.Success)
                return BadRequest(result.Message);

            orderBatchDTO = _mapper.Map<OrderBatch, OrderBatchDTO>(result.OrderBatch);
            return Ok(orderBatchDTO);
        }

        // PUT: api/Resignees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] OrderBatchDTO orderBatchDTO)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState.GetErrorMessages());

            var orderBatch = _mapper.Map<OrderBatchDTO, OrderBatch>(orderBatchDTO);
            var result = await _orderBatchService.UpdateAsync(id, orderBatch);

            if (!result.Success)
                return BadRequest(result.Message);

            orderBatchDTO = _mapper.Map<OrderBatch, OrderBatchDTO>(result.OrderBatch);
            return Ok(orderBatchDTO);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _orderBatchService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var orderBatchDTO = _mapper.Map<OrderBatch, OrderBatchDTO>(result.OrderBatch);
            return Ok(orderBatchDTO);
        }
    }
}

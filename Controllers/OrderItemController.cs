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
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;
        private readonly IMapper _mapper;
        public OrderItemController(IOrderItemService orderItemService, IMapper mapper)
        {
            _orderItemService = orderItemService;
            _mapper = mapper;
        }
        // GET: api/Employees
        [HttpGet]
        public async Task<IEnumerable<OrderItemDTO>> GetAllAsync()
        {
            var OrderItem = await _orderItemService.ListAsync();
            var OrderItemDTO = _mapper.Map<IEnumerable<OrderItem>, IEnumerable<OrderItemDTO>>(OrderItem);

            return OrderItemDTO;
        }

        // GET: api/Resignees/5
        [HttpGet("{id}")]
        public async Task<OrderItemDTO> GetAsync(int id)
        {

            var OrderItem = await _orderItemService.GetAsync(id);
            var OrderItemDTO = _mapper.Map<OrderItem, OrderItemDTO>(OrderItem);
            return OrderItemDTO;

        }

        // POST: api/Resignees
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] OrderItemDTO requestorDTO)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState.GetErrorMessages());

            var orderItem = _mapper.Map<OrderItemDTO, OrderItem>(requestorDTO);
            var result = await _orderItemService.PostAsync(orderItem);

            if (!result.Success)
                return BadRequest(result.Message);

            requestorDTO = _mapper.Map<OrderItem, OrderItemDTO>(result.OrderItem);
            return Ok(requestorDTO);
        }

        // PUT: api/Resignees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] OrderItemDTO requestorDTO)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState.GetErrorMessages());

            var orderItem = _mapper.Map<OrderItemDTO, OrderItem>(requestorDTO);
            var result = await _orderItemService.UpdateAsync(id, orderItem);

            if (!result.Success)
                return BadRequest(result.Message);

            requestorDTO = _mapper.Map<OrderItem, OrderItemDTO>(result.OrderItem);
            return Ok(requestorDTO);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _orderItemService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var requestorDTO = _mapper.Map<OrderItem, OrderItemDTO>(result.OrderItem);
            return Ok(requestorDTO);
        }
    }
}

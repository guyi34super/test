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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }
        // GET: api/Employees
        [HttpGet]
        public async Task<IEnumerable<OrderDTO>> GetAllAsync()
        {
            var Order = await _orderService.ListAsync();
            var OrderDTO = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(Order);

            return OrderDTO;
        }

        // GET: api/Resignees/5
        [HttpGet("{id}")]
        public async Task<OrderDTO> GetAsync(int id)
        {

            var Order = await _orderService.GetAsync(id);
            var OrderDTO = _mapper.Map<Order, OrderDTO>(Order);
            return OrderDTO;

        }

        // POST: api/Resignees
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] OrderDTO orderDTO)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState.GetErrorMessages());

            var order = _mapper.Map<OrderDTO, Order>(orderDTO);
            var result = await _orderService.PostAsync(order);

            if (!result.Success)
                return BadRequest(result.Message);

            orderDTO = _mapper.Map<Order, OrderDTO>(result.Order);
            return Ok(orderDTO);
        }

        // PUT: api/Resignees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] OrderDTO orderDTO)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState.GetErrorMessages());

            var order = _mapper.Map<OrderDTO, Order>(orderDTO);
            var result = await _orderService.UpdateAsync(id, order);

            if (!result.Success)
                return BadRequest(result.Message);

            orderDTO = _mapper.Map<Order, OrderDTO>(result.Order);
            return Ok(orderDTO);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _orderService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var orderDTO = _mapper.Map<Order, OrderDTO>(result.Order);
            return Ok(orderDTO);
        }
    }
}

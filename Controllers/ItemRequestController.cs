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
    public class ItemRequestController : ControllerBase
    {
        private readonly IItemRequestService _ItemRequestService;
        private readonly IMapper _mapper;
        public ItemRequestController(IItemRequestService itemRequestService, IMapper mapper)
        {
            _ItemRequestService = itemRequestService;
            _mapper = mapper;
        }
        // GET: api/Employees
        [HttpGet]
        public async Task<IEnumerable<ItemRequestDTO>> GetAllAsync()
        {
            var ItemRequest = await _ItemRequestService.ListAsync();
            var ItemRequestDTO = _mapper.Map<IEnumerable<ItemRequest>, IEnumerable<ItemRequestDTO>>(ItemRequest);

            return ItemRequestDTO;
        }

        // GET: api/Resignees/5
        [HttpGet("{id}")]
        public async Task<ItemRequestDTO> GetAsync(int id)
        {

            var ItemRequest = await _ItemRequestService.GetAsync(id);
            var ItemRequestDTO = _mapper.Map<ItemRequest, ItemRequestDTO>(ItemRequest);
            return ItemRequestDTO;

        }

        // POST: api/Resignees
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ItemRequestDTO itemRequestDTO)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState.GetErrorMessages());

            var itemRequest = _mapper.Map<ItemRequestDTO, ItemRequest>(itemRequestDTO);
            var result = await _ItemRequestService.PostAsync(itemRequest);

            if (!result.Success)
                return BadRequest(result.Message);

            itemRequestDTO = _mapper.Map<ItemRequest, ItemRequestDTO>(result.ItemRequest);
            return Ok(itemRequestDTO);
        }

        // PUT: api/Resignees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] ItemRequestDTO itemRequestDTO)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState.GetErrorMessages());

            var itemRequest = _mapper.Map<ItemRequestDTO, ItemRequest>(itemRequestDTO);
            var result = await _ItemRequestService.UpdateAsync(id, itemRequest);

            if (!result.Success)
                return BadRequest(result.Message);

            itemRequestDTO = _mapper.Map<ItemRequest, ItemRequestDTO>(result.ItemRequest);
            return Ok(itemRequestDTO);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _ItemRequestService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var itemRequestDTO = _mapper.Map<ItemRequest, ItemRequestDTO>(result.ItemRequest);
            return Ok(itemRequestDTO);
        }
    }
}

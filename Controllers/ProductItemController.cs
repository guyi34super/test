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
    public class ProductItemController : ControllerBase
    {
        private readonly IProductItemService _productItemService;
        private readonly IMapper _mapper;
        public ProductItemController(IProductItemService productItemService, IMapper mapper)
        {
            _productItemService = productItemService;
            _mapper = mapper;
        }
        // GET: api/Employees
        [HttpGet]
        public async Task<IEnumerable<ProductItemDTO>> GetAllAsync()
        {
            var ProductItem = await _productItemService.ListAsync();
            var ProductItemDTO = _mapper.Map<IEnumerable<ProductItem>, IEnumerable<ProductItemDTO>>(ProductItem);

            return ProductItemDTO;
        }

        // GET: api/Resignees/5
        [HttpGet("{id}")]
        public async Task<ProductItemDTO> GetAsync(int id)
        {

            var ProductItem = await _productItemService.GetAsync(id);
            var ProductItemDTO = _mapper.Map<ProductItem, ProductItemDTO>(ProductItem);
            return ProductItemDTO;

        }

        // POST: api/Resignees
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ProductItemDTO productItemDTO)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState.GetErrorMessages());

            var productItem = _mapper.Map<ProductItemDTO, ProductItem>(productItemDTO);
            var result = await _productItemService.PostAsync(productItem);

            if (!result.Success)
                return BadRequest(result.Message);

            productItemDTO = _mapper.Map<ProductItem, ProductItemDTO>(result.ProductItem);
            return Ok(productItemDTO);
        }

        // PUT: api/Resignees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] ProductItemDTO productItemDTO)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState.GetErrorMessages());

            var productItem = _mapper.Map<ProductItemDTO, ProductItem>(productItemDTO);
            var result = await _productItemService.UpdateAsync(id, productItem);

            if (!result.Success)
                return BadRequest(result.Message);

            productItemDTO = _mapper.Map<ProductItem, ProductItemDTO>(result.ProductItem);
            return Ok(productItemDTO);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productItemService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var productItemDTO = _mapper.Map<ProductItem, ProductItemDTO>(result.ProductItem);
            return Ok(productItemDTO);
        }
    }
}

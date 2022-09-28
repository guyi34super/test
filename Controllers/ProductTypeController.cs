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
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeService _productTypeService;
        private readonly IMapper _mapper;
        public ProductTypeController(IProductTypeService productTypeService, IMapper mapper)
        {
            _productTypeService = productTypeService;
            _mapper = mapper;
        }
        // GET: api/Employees
        [HttpGet]
        public async Task<IEnumerable<ProductTypeDTO>> GetAllAsync()
        {
            var ProductType = await _productTypeService.ListAsync();
            var ProductTypeDTO = _mapper.Map<IEnumerable<ProductType>, IEnumerable<ProductTypeDTO>>(ProductType);

            return ProductTypeDTO;
        }

        // GET: api/Resignees/5
        [HttpGet("{id}")]
        public async Task<ProductTypeDTO> GetAsync(int id)
        {

            var ProductType = await _productTypeService.GetAsync(id);
            var ProductTypeDTO = _mapper.Map<ProductType, ProductTypeDTO>(ProductType);
            return ProductTypeDTO;

        }

        // POST: api/Resignees
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ProductTypeDTO productTypeDTO)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState.GetErrorMessages());

            var productType = _mapper.Map<ProductTypeDTO, ProductType>(productTypeDTO);
            var result = await _productTypeService.PostAsync(productType);

            if (!result.Success)
                return BadRequest(result.Message);

            productTypeDTO = _mapper.Map<ProductType, ProductTypeDTO>(result.ProductType);
            return Ok(productTypeDTO);
        }

        // PUT: api/Resignees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] ProductTypeDTO productTypeDTO)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState.GetErrorMessages());

            var productType = _mapper.Map<ProductTypeDTO, ProductType>(productTypeDTO);
            var result = await _productTypeService.UpdateAsync(id, productType);

            if (!result.Success)
                return BadRequest(result.Message);

            productTypeDTO = _mapper.Map<ProductType, ProductTypeDTO>(result.ProductType);
            return Ok(productTypeDTO);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productTypeService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var productTypeDTO = _mapper.Map<ProductType, ProductTypeDTO>(result.ProductType);
            return Ok(productTypeDTO);
        }
    }
}

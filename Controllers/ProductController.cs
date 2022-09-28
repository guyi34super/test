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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        // GET: api/Employees
        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var Product = await _productService.ListAsync();
            var ProductDTO = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(Product);

            return ProductDTO;
        }

        // GET: api/Resignees/5
        [HttpGet("{id}")]
        public async Task<ProductDTO> GetAsync(int id)
        {

            var Product = await _productService.GetAsync(id);
            var ProductDTO = _mapper.Map<Product, ProductDTO>(Product);
            return ProductDTO;

        }

        // POST: api/Resignees
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ProductDTO requestorDTO)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState.GetErrorMessages());

            var product = _mapper.Map<ProductDTO, Product>(requestorDTO);
            var result = await _productService.PostAsync(product);

            if (!result.Success)
                return BadRequest(result.Message);

            requestorDTO = _mapper.Map<Product, ProductDTO>(result.Product);
            return Ok(requestorDTO);
        }

        // PUT: api/Resignees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] ProductDTO requestorDTO)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState.GetErrorMessages());

            var product = _mapper.Map<ProductDTO, Product>(requestorDTO);
            var result = await _productService.UpdateAsync(id, product);

            if (!result.Success)
                return BadRequest(result.Message);

            requestorDTO = _mapper.Map<Product, ProductDTO>(result.Product);
            return Ok(requestorDTO);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var requestorDTO = _mapper.Map<Product, ProductDTO>(result.Product);
            return Ok(requestorDTO);
        }
    }
}

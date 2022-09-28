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
    public class ProductLineController : ControllerBase
    {
        private readonly IProductLineService _productLineService;
        private readonly IMapper _mapper;
        public ProductLineController(IProductLineService productLineService, IMapper mapper)
        {
            _productLineService = productLineService;
            _mapper = mapper;
        }
        // GET: api/Employees
        [HttpGet]
        public async Task<IEnumerable<ProductLineDTO>> GetAllAsync()
        {
            var ProductLine = await _productLineService.ListAsync();
            var ProductLineDTO = _mapper.Map<IEnumerable<ProductLine>, IEnumerable<ProductLineDTO>>(ProductLine);

            return ProductLineDTO;
        }

        // GET: api/Resignees/5
        [HttpGet("{id}")]
        public async Task<ProductLineDTO> GetAsync(int id)
        {

            var ProductLine = await _productLineService.GetAsync(id);
            var ProductLineDTO = _mapper.Map<ProductLine, ProductLineDTO>(ProductLine);
            return ProductLineDTO;

        }

        // POST: api/Resignees
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ProductLineDTO productLineDTO)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState.GetErrorMessages());

            var productLine = _mapper.Map<ProductLineDTO, ProductLine>(productLineDTO);
            var result = await _productLineService.PostAsync(productLine);

            if (!result.Success)
                return BadRequest(result.Message);

            productLineDTO = _mapper.Map<ProductLine, ProductLineDTO>(result.ProductLine);
            return Ok(productLineDTO);
        }

        // PUT: api/Resignees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] ProductLineDTO productLineDTO)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState.GetErrorMessages());

            var productLine = _mapper.Map<ProductLineDTO, ProductLine>(productLineDTO);
            var result = await _productLineService.UpdateAsync(id, productLine);

            if (!result.Success)
                return BadRequest(result.Message);

            productLineDTO = _mapper.Map<ProductLine, ProductLineDTO>(result.ProductLine);
            return Ok(productLineDTO);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productLineService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var productLineDTO = _mapper.Map<ProductLine, ProductLineDTO>(result.ProductLine);
            return Ok(productLineDTO);
        }
    }
}

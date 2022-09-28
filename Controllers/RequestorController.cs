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
    public class RequestorController : ControllerBase
    {
        private readonly IRequestorService _requestorService;
        private readonly IMapper _mapper;
        public RequestorController(IRequestorService requestorService, IMapper mapper)
        {
            _requestorService = requestorService;
            _mapper = mapper;
        }
        // GET: api/Requestors
        [HttpGet]
        public async Task<IEnumerable<RequestorDTO>> GetAllAsync()
        {
            var Requestor = await _requestorService.ListAsync();
            var RequestorDTO = _mapper.Map<IEnumerable<Requestor>, IEnumerable<RequestorDTO>>(Requestor);

            return RequestorDTO;
        }

        // GET: api/Requestor/5
        [HttpGet("{id}")]
        public async Task<RequestorDTO> GetAsync(int id)
        {

            var Requestor = await _requestorService.GetAsync(id);
            var RequestorDTO = _mapper.Map<Requestor, RequestorDTO>(Requestor);
            return RequestorDTO;

        }

        // POST: api/Requestors
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] RequestorDTO requestorDTO)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState.GetErrorMessages());

            var requestor = _mapper.Map<RequestorDTO, Requestor>(requestorDTO);
            var result = await _requestorService.PostAsync(requestor);

            if (!result.Success)
                return BadRequest(result.Message);

            requestorDTO = _mapper.Map<Requestor, RequestorDTO>(result.Requestor);
            return Ok(requestorDTO);
        }

        // PUT: api/Requestor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] RequestorDTO requestorDTO)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState.GetErrorMessages());

            var requestor = _mapper.Map<RequestorDTO, Requestor>(requestorDTO);
            var result = await _requestorService.UpdateAsync(id, requestor);

            if (!result.Success)
                return BadRequest(result.Message);

            requestorDTO = _mapper.Map<Requestor, RequestorDTO>(result.Requestor);
            return Ok(requestorDTO);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _requestorService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var requestorDTO = _mapper.Map<Requestor, RequestorDTO>(result.Requestor);
            return Ok(requestorDTO);
        }
    }
}

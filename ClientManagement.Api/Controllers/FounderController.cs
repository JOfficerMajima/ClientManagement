using AutoMapper;
using ClientManagement.Application.Founders;
using ClientManagement.Application.Founders.Dtos;
using ClientManagement.Domain;
using ClientManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ClientManagement.Api.Controllers
{
    public class FounderController : BaseApiController
    {
        private readonly IFounderService _founderService;
        private readonly IMapper _mapper;

        public FounderController(ApplicationDbContext context,
            IFounderService founderService,
            IMapper mapper) : base(context)
        {
            _founderService = founderService;
            _mapper = mapper;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] FounderDto dto)
        {
            var founder = _mapper.Map<Founder>(dto);
            await _founderService.AddAsync(founder);
            return Ok();
        }

        [HttpGet("[action]")]
        [ProducesResponseType(typeof(FounderDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var founder = await _founderService.GetByIdAsync(id);
            if (founder == null)
                return NotFound();

            return Ok(_mapper.Map<FounderDto>(founder));
        }

        [HttpGet("[action]")]
        [ProducesResponseType(typeof(FounderDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetByINN(int inn)
        {
            var founder = await _founderService.GetByINNAsync(inn);
            if (founder == null)
                return NotFound();

            return Ok(_mapper.Map<FounderDto>(founder));
        }


        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IEnumerable<FounderDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            var founders = await _founderService.GetAllAsync();
            return Ok(founders);
        }

        [HttpPut("[action]")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> Update([FromBody] UpdateFounderDto dto)
        {
            var founder = _mapper.Map<Founder>(dto);
            await _founderService.UpdateAsync(founder);
            return NoContent();
        }

        [HttpDelete("[action]")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Remove(int id)
        {
            await _founderService.DeleteAsync(id);
            return NoContent();
        }
    }
}

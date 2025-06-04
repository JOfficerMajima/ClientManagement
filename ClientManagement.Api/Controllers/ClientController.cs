using AutoMapper;
using ClientManagement.Application.Clients;
using ClientManagement.Application.Clients.Dtos;
using ClientManagement.Domain;
using ClientManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ClientManagement.Api.Controllers
{
    public class ClientController : BaseApiController
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientController(
            ApplicationDbContext context,
            IClientService clientService,
            IMapper mapper) : base(context)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] ClientDto dto)
        {
            var client = _mapper.Map<Client>(dto);
            await _clientService.AddAsync(client);
            return Ok();
        }

        [HttpGet("[action]")]
        [ProducesResponseType(typeof(ClientDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var client = await _clientService.GetByIdAsync(id);
            if (client == null)
                return NotFound();

            return Ok(_mapper.Map<ClientDto>(client));
        }

        [HttpGet("[action]")]
        [ProducesResponseType(typeof(ClientDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetByINN(int inn)
        {
            var client = await _clientService.GetByINNAsync(inn);
            if (client == null)
                return NotFound();

            return Ok(_mapper.Map<ClientDto>(client));
        }


        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IEnumerable<ClientDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            var clients = await _clientService.GetAllAsync();
            return Ok(clients);
        }

        [HttpPut("[action]")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> Update([FromBody] UpdateClientDto dto)
        {
            var client = _mapper.Map<Client>(dto);
            await _clientService.UpdateAsync(client);
            return NoContent();
        }

        [HttpDelete("[action]")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Remove(int id)
        {
            await _clientService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("[action]")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<ClientWithFoundersDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetClientWithFounders(int id)
        {
            var result = await _clientService.GetClientWithFoundersAsync(id);
            return Ok(result);
        }
    }
}

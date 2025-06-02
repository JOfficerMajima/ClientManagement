using ClientManagement.Application.Interfaces;
using ClientManagement.Application.Repositories;
using ClientManagement.Domain;
using ClientManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ClientManagement.Api.Controllers
{
    public class ClientController : BaseApiController
    {
        private readonly IClientRepository _clientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ClientController(
            ApplicationDbContext context,
            IClientRepository clientRepository,
            IUnitOfWork unitOfWork) : base(context)
        {
            _clientRepository = clientRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddAsync(Client client)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                await _clientRepository.AddAsync(client);

                await _unitOfWork.CommitAsync();

                return Ok(client);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]")]
        [ProducesResponseType(typeof(Client), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var client = await _clientRepository.GetByIdAsync(id);

                return Ok(client);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                await _clientRepository.DeleteAsync(id);

                await _unitOfWork.CommitAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                return BadRequest(ex.Message);
            }
        }


    }
}

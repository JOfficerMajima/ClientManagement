using AutoMapper;
using ClientManagement.Api.Controllers;
using ClientManagement.Application.Clients;
using ClientManagement.Application.Clients.Dtos;
using ClientManagement.Domain;
using ClientManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ClientManagement.Api.Tests.Controllers
{
    public class ClientControllerTests
    {
        private readonly Mock<IClientService> _mockClientService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ClientController _controller;

        public ClientControllerTests()
        {
            _mockClientService = new Mock<IClientService>();
            _mockMapper = new Mock<IMapper>();

            _controller = new ClientController(
                _mockClientService.Object,
                _mockMapper.Object);
        }

        [Fact]
        public async Task Add_ValidClient_ReturnsOkResult()
        {
            var clientDto = new ClientDto
            {
                Id = 1,
                Name = "Test Client",
                INN = 1234567890
            };

            var client = new Client
            {
                Id = 1,
                Name = "Test Client",
                INN = 1234567890
            };

            _mockMapper.Setup(m => m.Map<Client>(clientDto))
                .Returns(client);

            _mockClientService.Setup(s => s.AddAsync(client))
                .Returns(Task.CompletedTask);

            var result = await _controller.Add(clientDto);

            Assert.IsType<OkResult>(result);

            _mockMapper.Verify(m => m.Map<Client>(clientDto), Times.Once);

            _mockClientService.Verify(s => s.AddAsync(client), Times.Once);
        }

        [Fact]
        public async Task GetById_ClientExists_ReturnsClientDto()
        {    
            var clientId = 1;
            var client = new Client { Id = clientId, Name = "Test Client" };
            var clientDto = new ClientDto { Id = clientId, Name = "Test Client" };

            _mockClientService.Setup(s => s.GetByIdAsync(clientId))
                .ReturnsAsync(client);
            _mockMapper.Setup(m => m.Map<ClientDto>(client))
                .Returns(clientDto);

            var result = await _controller.GetById(clientId);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedDto = Assert.IsType<ClientDto>(okResult.Value);
            Assert.Equal(clientId, returnedDto.Id);
        }

        [Fact]
        public async Task GetById_ClientNotExists_ReturnsNotFound()
        {
            var clientId = 999;
            _mockClientService.Setup(s => s.GetByIdAsync(clientId))
                .ReturnsAsync((Client)null);

            var result = await _controller.GetById(clientId);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Update_ValidClient_ReturnsNoContent()
        {
            var updateDto = new UpdateClientDto { Id = 1, Name = "Updated Name" };
            var client = new Client { Id = 1, Name = "Updated Name" };

            _mockMapper.Setup(m => m.Map<Client>(updateDto))
                .Returns(client);
            _mockClientService.Setup(s => s.UpdateAsync(client))
                .Returns(Task.CompletedTask);

            var result = await _controller.Update(updateDto);

            Assert.IsType<NoContentResult>(result);
            _mockClientService.Verify(s => s.UpdateAsync(client), Times.Once);
        }

        [Fact]
        public async Task Remove_ClientExists_ReturnsNoContent()
        {
            var clientId = 1;
            _mockClientService.Setup(s => s.DeleteAsync(clientId))
                .Returns(Task.CompletedTask);

            var result = await _controller.Remove(clientId);

            Assert.IsType<NoContentResult>(result);
            _mockClientService.Verify(s => s.DeleteAsync(clientId), Times.Once);
        }
    }
}
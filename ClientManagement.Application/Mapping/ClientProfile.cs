using AutoMapper;
using ClientManagement.Application.Clients.Dtos;
using ClientManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagement.Application.Mapping
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientDto>();
            CreateMap<ClientDto, Client>();
        }
    }
}

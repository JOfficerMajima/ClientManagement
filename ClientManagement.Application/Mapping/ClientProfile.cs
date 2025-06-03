using AutoMapper;
using ClientManagement.Application.Clients.Dtos;
using ClientManagement.Domain.Entities;

namespace ClientManagement.Application.Mapping
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientDto>();
            CreateMap<ClientDto, Client>();
            CreateMap<UpdateClientDto, Client>();
            CreateMap<Client, UpdateClientDto>();
            CreateMap<Client, ClientWithFoundersDto>().
                ForMember(dest => dest.Founders, opt => opt.MapFrom(src => src.FounderClients.Select(fc => fc.Founder)));
        }
    }
}

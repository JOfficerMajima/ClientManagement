using AutoMapper;
using ClientManagement.Application.Founders.Dtos;
using ClientManagement.Domain.Entities;

namespace ClientManagement.Application.Mapping
{
    public class FounderProfile : Profile
    {
        public FounderProfile()
        {
            CreateMap<Founder, FounderDto>();
            CreateMap<FounderDto, Founder>();
            CreateMap<UpdateFounderDto, Founder>();
            CreateMap<Founder, UpdateFounderDto>();
            CreateMap<ShortFounderDto, Founder>();
            CreateMap<Founder, ShortFounderDto>();
        }
    }
}

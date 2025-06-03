using AutoMapper;
using ClientManagement.Application.Founders.Dtos;
using ClientManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagement.Application.Mapping
{
    public class FounderProfile : Profile
    {
        public FounderProfile()
        {
            CreateMap<Founder, FounderDto>();
            CreateMap<FounderDto, Founder>();
        }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DTO;
using Tickets.Model;

namespace Tickets.Utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Equipo, EquipoDTO>().ReverseMap();
        }
    }
}

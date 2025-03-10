using AutoMapper;
using OeX.Dashboard.Application.Commons;
using OeX.Dashboard.Domain.Maquinas;

namespace OeX.Dashboard.API.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Maquina, SelectFiltroDto>()
               .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Nome))
               .ReverseMap();
        }
    }
}

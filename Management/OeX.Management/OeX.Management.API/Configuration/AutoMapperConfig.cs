using AutoMapper;
using OeX.Management.Application.MotivosParada.DTOs;
using OeX.Management.Domain.MotivosParada;

namespace OeX.Management.API.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<MotivoParada, MotivoParadaDTO>().ReverseMap();
        }
    }
}

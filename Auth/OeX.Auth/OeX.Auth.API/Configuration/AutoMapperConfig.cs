using AutoMapper;
using OeX.Auth.Application.Usuarios.Dtos;
using OeX.Auth.Domain.Usuarios;

namespace OeX.Auth.API.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
        }
    }
}

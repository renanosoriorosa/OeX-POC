﻿namespace OeX.Auth.Application.Usuarios.Dtos
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public Guid EmpresaId { get; set; }
    }
}

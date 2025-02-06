namespace OeX.Auth.Application.Empresas.Dtos
{
    public class EmpresaDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public int TempoTrabalho { get; set; }
    }
}

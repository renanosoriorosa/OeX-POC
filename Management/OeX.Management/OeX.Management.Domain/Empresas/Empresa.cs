﻿using OeX.Management.Domain.Commons;


namespace OeX.Management.Domain.Empresas
{
    public class Empresa : Entity<Guid>
    {
        public string Nome { get; private set; }
        public string CNPJ { get; private set; }
        public int TempoTrabalho { get; private set; }
        public Empresa() { }

        public Empresa(string nome, string cNPJ, int tempoTrabalho)
        {
            Nome = nome;
            CNPJ = cNPJ;
            TempoTrabalho = tempoTrabalho;
        }
    }
}

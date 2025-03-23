using OeX.Management.Domain.Manutecoes;
using OeX.Management.Domain.Manutecoes.Interfaces;
using OeX.Management.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OeX.Management.Infrastructure.Repository.Manutencoes
{
    public class ManutencaoRepository : IManutencaoRepository
    {
        private readonly RNContext _rnContext;
        public ManutencaoRepository(RNContext rnContext)
        {
            _rnContext = rnContext;
        }

        public void Adicionar(Manutencao entity)
        {
            _rnContext.Manutencoes.Add(entity);
            _rnContext.SaveChanges();
        }

        public void Atualizar(Manutencao entity)
        {
            _rnContext.Manutencoes.Update(entity);
            _rnContext.SaveChanges();
        }

        public void Remover(Manutencao entity)
        {
            _rnContext.Manutencoes.Remove(entity); //se tiver só o id preenchido remove igual
            _rnContext.SaveChanges();
        }

    }
}

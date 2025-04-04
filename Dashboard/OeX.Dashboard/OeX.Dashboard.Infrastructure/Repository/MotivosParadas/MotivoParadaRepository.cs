﻿using Microsoft.EntityFrameworkCore;
using OeX.Dashboard.Domain.MotivosParada;
using OeX.Dashboard.Domain.MotivosParada.Interfaces;
using OeX.Dashboard.Infrastructure.Context;

namespace OeX.Dashboard.Infrastructure.Repository.MotivoParadaRepository
{
    public class MotivoParadaRepository : IMotivoParadaRepository
    {
        private readonly RNContext _context;

        public MotivoParadaRepository(RNContext context)
        {
            _context = context;
        }

        public async Task<MotivoParada?> BuscarPorIdManagementEEmpresa(
            long managementId,
            Guid empresaId)
        {
            return await _context.MotivosParada
                           .FirstOrDefaultAsync(x => 
                                    x.ManagementId == managementId &&
                                    x.EmpresaId == empresaId);
        }

        public void Adicionar(MotivoParada entity)
        {
            _context.Add(entity);
        }

        public void Atualizar(MotivoParada entity)
        {
            _context.Update(entity);
        }

        public void Remover(MotivoParada entity)
        {
            _context.Remove(entity);
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteDesenvolvedor.Domain;
using TesteDesenvolvedor.Repository.Context;
using TesteDesenvolvedor.Repository.Generic;
using TesteDesenvolvedor.Repository.Interface;

namespace TesteDesenvolvedor.Repository
{
    public class PosicaoVeiculoRepository : GenericRepository, IPosicaoVeiculoRepository
    {

        public PosicaoVeiculoRepository(DataContext context) : base(context){}
        
        public async Task<PosicaoVeiculo> FindById(int id)
        {
            var result = await _context.PosicaoVeiculos.SingleOrDefaultAsync(l => l.VeiculoId.Equals(id));
            return result;
        }

        public async Task<List<PosicaoVeiculo>> GetAll()
        {
            var result = await _context.PosicaoVeiculos.ToListAsync();
            return result;
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteDesenvolvedor.Domain;
using TesteDesenvolvedor.Repository.Context;
using TesteDesenvolvedor.Repository.Generic;
using TesteDesenvolvedor.Repository.Interface;

namespace TesteDesenvolvedor.Repository
{
    public class LinhaRepository : GenericRepository, ILinhaRepository
    {
        public LinhaRepository(DataContext context) : base (context){}
        
        public async Task<Linha> FindById(int id)
        {
            var result = await _context.Linhas.SingleOrDefaultAsync(l => l.Id.Equals(id));
            return result;
        }

        public async Task<List<Linha>> GetAll()
        {
            var result = await _context.Linhas.Include(p => p.Paradas).AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<List<Linha>> FindAllLinhasByParadas(int paradaId)
        {
            var result = await _context.Linhas
                    .Include(p => p.Paradas)
                    .Where(p => p.ParadaId.Equals(paradaId)).AsNoTracking()
                    .ToListAsync();
            return result;
        }

    }
}
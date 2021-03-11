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
        
        public async Task<Linha> FindByIdAsync(long id)
        {
            var result = await _context.Linhas.SingleOrDefaultAsync(l => l.Id.Equals(id));
            return result;
        }

        public async Task<List<Linha>> GetAllAsync()
        {
            var result = await _context.Linhas
                    .Include(x => x.LinhasParadas)
                    .ThenInclude(p => p.Parada).AsNoTracking()
                    .ToListAsync();
            return result;
        }

        public async Task<List<Linha>> FindAllLinhasByParadasAsync(long paradaId)
        {
            var result = await _context.Linhas
                    .Include(x => x.LinhasParadas)
                    .ThenInclude(p => p.Parada).AsNoTracking()
                    .Where(p => p.LinhasParadas.All(x => x.Parada.Id.Equals(paradaId)))
                    .ToListAsync(); 
            return result;
        }

    }
}
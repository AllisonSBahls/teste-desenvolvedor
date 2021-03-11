using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteDesenvolvedor.Domain;
using TesteDesenvolvedor.Repository.Context;
using TesteDesenvolvedor.Repository.Generic;
using TesteDesenvolvedor.Repository.Interface;

namespace TesteDesenvolvedor.Repository
{
    public class ParadaRepository : GenericRepository, IParadaRepository
    {

        public ParadaRepository(DataContext context) : base(context){}
        
        public async Task<Parada> FindByIdAsync(long id)
        {
            var result = await _context.Paradas.AsNoTracking().SingleOrDefaultAsync(p => p.Id.Equals(id));
            return result;
        }

        public async Task<List<Parada>> GetAllAsync()
        {
            var result = await _context.Paradas.ToListAsync();
            return result;
        }
    }
}
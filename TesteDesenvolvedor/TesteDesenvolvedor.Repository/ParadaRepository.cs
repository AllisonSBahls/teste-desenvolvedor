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
            var result = await _context.Paradas.AsNoTracking()
                            .SingleOrDefaultAsync(p => p.Id.Equals(id));
            return result;
        }

        public async Task<List<Parada>> GetAllAsync()
        {
            var result = await _context.Paradas
                        .Include(lp => lp.LinhaParadas)
                            .ThenInclude(l => l.Linha).
                            AsNoTracking().ToListAsync();
            return result;
        }
        public async Task<List<Parada>> FindParadaByPosicao(double lat, double lng, double distance)
        {
            var result = await _context.Paradas
                .FromSqlRaw(@"SELECT *, ( 3959 * acos( cos( radians({0}) ) * cos( radians( paradas.Latitude ) ) * cos(radians(longitude) - radians({1})) + sin(radians({0})) * sin(radians(latitude))) ) AS distance FROM paradas  HAVING distance < {2} ORDER BY distance", lat, lng, distance).ToListAsync();

            return result;
         
                         
        }

    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteDesenvolvedor.Domain;
using TesteDesenvolvedor.Repository.Generic;

namespace TesteDesenvolvedor.Repository.Interface
{
    public interface IParadaRepository : IRepository
    {
        Task<Parada> FindByIdAsync(int id);
        Task<List<Parada>> GetAllAsync();
    }
}
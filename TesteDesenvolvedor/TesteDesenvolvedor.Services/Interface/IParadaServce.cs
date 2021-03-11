using System.Collections.Generic;
using System.Threading.Tasks;
using TesteDesenvolvedor.Domain;

namespace TesteDesenvolvedor.Services.Interface
{
    public interface IParadaService
    {
        Task<Parada> FindByIdParadaAsync(long id);
        Task<List<Parada>> GetAllParadasAsync();
        Task<Parada> AddParadaAsync(Parada parada);
        Task<Parada> UpdateParadaAsync(long id, Parada parada);
        Task<bool> DeleteParadaAsync(long id);
    }
}
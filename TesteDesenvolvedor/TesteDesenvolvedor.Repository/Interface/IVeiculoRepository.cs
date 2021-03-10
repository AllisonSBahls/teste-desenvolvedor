using System.Collections.Generic;
using System.Threading.Tasks;
using TesteDesenvolvedor.Domain;
using TesteDesenvolvedor.Repository.Generic;

namespace TesteDesenvolvedor.Repository.Interface
{
    public interface IVeiculoRepository : IRepository
    {
        Task<Veiculo> FindByIdAsync(int id);
        Task<List<Veiculo>> GetAllAsync();
        Task<List<Veiculo>> FindAllVeiculosByLinhasAsync(int linhaId);
    }
}
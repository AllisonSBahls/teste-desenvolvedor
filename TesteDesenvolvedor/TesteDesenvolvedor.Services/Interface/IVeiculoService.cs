using System.Collections.Generic;
using System.Threading.Tasks;
using TesteDesenvolvedor.Domain;

namespace TesteDesenvolvedor.Services.Interface
{
    public interface IVeiculoService
    {
         Task<Veiculo> FindByIdVeiculoAsync(long id);
        Task<List<Veiculo>> GetAllVeiculosAsync();
        Task<Veiculo> AddVeiculoAsync(Veiculo veiculo);
        Task<Veiculo> UpdateVeiculoAsync(long id, Veiculo veiculo);
        Task<bool> DeleteVeiculoAsync(long id);
        Task<List<Veiculo>> FindAllVeiculosByLinhasAsync(long linhaId);
    }
}
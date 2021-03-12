using System.Collections.Generic;
using System.Threading.Tasks;
using TesteDesenvolvedor.Domain;
using TesteDesenvolvedor.Services.DTOs;

namespace TesteDesenvolvedor.Services.Interface
{
    public interface IVeiculoService
    {
         Task<VeiculoDTO> FindByIdVeiculoAsync(long id);
        Task<List<VeiculoDTO>> GetAllVeiculosAsync();
        Task<VeiculoDTO> AddVeiculoAsync(VeiculoDTO veiculoDTO);
        Task<VeiculoDTO> UpdateVeiculoAsync(long id, VeiculoDTO veiculoDTO);
        Task<bool> DeleteVeiculoAsync(long id);
        Task<List<VeiculoDTO>> FindAllVeiculosByLinhasAsync(long linhaId);
    }
}
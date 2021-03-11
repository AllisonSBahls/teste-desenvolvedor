using System.Collections.Generic;
using System.Threading.Tasks;
using TesteDesenvolvedor.Domain;

namespace TesteDesenvolvedor.Services.Interface
{
    public interface IPosicaoVeiculoService
    {
         Task<PosicaoVeiculo> FindByIdPosicaoVeiculoAsync(long id);
        Task<List<PosicaoVeiculo>> GetAllPosicaoVeiculosAsync();
        Task<PosicaoVeiculo> AddPosicaoVeiculoAsync(PosicaoVeiculo posicaoVeiculo);
        Task<PosicaoVeiculo> UpdatePosicaoVeiculoAsync(long id, PosicaoVeiculo posicaoVeiculo);
        Task<PosicaoVeiculo> DeletePosicaoVeiculoAsync(long id);
    }
}
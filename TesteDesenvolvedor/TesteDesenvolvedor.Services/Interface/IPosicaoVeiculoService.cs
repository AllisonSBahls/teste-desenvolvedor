using System.Collections.Generic;
using System.Threading.Tasks;
using TesteDesenvolvedor.Domain;

namespace TesteDesenvolvedor.Services.Interface
{
    public interface IPosicaoVeiculoService
    {
        Task<PosicaoVeiculo> FindByIdPosicaoVeiculoAsync(long veiculoId);
        Task<List<PosicaoVeiculo>> GetAllPosicaoVeiculosAsync();
        Task<PosicaoVeiculo> AddPosicaoVeiculoAsync(PosicaoVeiculo posicaoVeiculo);
        Task<PosicaoVeiculo> UpdatePosicaoVeiculoAsync(long veiculoId, PosicaoVeiculo posicaoVeiculo);
        Task<bool> DeletePosicaoVeiculoAsync(long veiculoId);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteDesenvolvedor.Domain;

namespace TesteDesenvolvedor.Services.Interface
{
    public interface IPosicaoVeiculoService
    {
        Task<PosicaoVeiculo> FindByIdPosicaoVeiculoAsync(double id);
        Task<List<PosicaoVeiculo>> GetAllPosicaoVeiculosAsync();
        Task<PosicaoVeiculo> AddPosicaoVeiculoAsync(PosicaoVeiculo posicaoVeiculo);
        Task<PosicaoVeiculo> UpdatePosicaoVeiculoAsync(double id, PosicaoVeiculo posicaoVeiculo);
        Task<bool> DeletePosicaoVeiculoAsync(double id);
    }
}
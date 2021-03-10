using System.Collections.Generic;
using System.Threading.Tasks;
using TesteDesenvolvedor.Domain;
using TesteDesenvolvedor.Repository.Generic;

namespace TesteDesenvolvedor.Repository.Interface
{
    public interface IPosicaoVeiculoRepository : IRepository
    {
        Task<PosicaoVeiculo> FindByIdAsync(int veiculoId);
        Task<List<PosicaoVeiculo>> GetAllAsync();
    }
}
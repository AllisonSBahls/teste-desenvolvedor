using System.Collections.Generic;
using System.Threading.Tasks;
using TesteDesenvolvedor.Domain;
using TesteDesenvolvedor.Repository.Generic;

namespace TesteDesenvolvedor.Repository.Interface
{
    public interface IPosicaoVeiculoRepository : IRepository
    {
        Task<PosicaoVeiculo> FindById(int veiculoId);
        Task<List<PosicaoVeiculo>> GetAll();
    }
}
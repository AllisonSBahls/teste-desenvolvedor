using System.Collections.Generic;
using System.Threading.Tasks;
using TesteDesenvolvedor.Domain;
using TesteDesenvolvedor.Repository.Generic;

namespace TesteDesenvolvedor.Repository.Interface
{
    public interface IVeiculoRepository : IRepository
    {
        Task<Veiculo> FindById(int id);
        Task<List<Veiculo>> GetAll();
        Task<List<Veiculo>> FindAllVeiculosByLinhas(int linhaId);
    }
}
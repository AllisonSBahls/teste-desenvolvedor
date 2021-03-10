using System.Collections.Generic;
using System.Threading.Tasks;
using TesteDesenvolvedor.Domain;
using TesteDesenvolvedor.Repository.Generic;

namespace TesteDesenvolvedor.Repository.Interface
{
    public interface ILinhaRepository : IRepository
    {
        Task<Linha> FindById(int id);
        Task<List<Linha>> GetAll();
        Task<List<Linha>> FindAllLinhasByParadas(int paradaId);
    }
}
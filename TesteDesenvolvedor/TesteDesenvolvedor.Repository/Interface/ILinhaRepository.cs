using System.Collections.Generic;
using System.Threading.Tasks;
using TesteDesenvolvedor.Domain;
using TesteDesenvolvedor.Repository.Generic;

namespace TesteDesenvolvedor.Repository.Interface
{
    public interface ILinhaRepository : IRepository
    {
        Task<Linha> FindByIdAsync(long id);
        Task<List<Linha>> GetAllAsync();
        Task<List<Linha>> FindAllLinhasByParadasAsync(long paradaId);
    }
}
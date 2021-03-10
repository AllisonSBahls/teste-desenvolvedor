using System.Threading.Tasks;
using TesteDesenvolvedor.Domain;

namespace TesteDesenvolvedor.Services.Interface
{
    public interface ILinhaService
    {
     Task<Linha> AddLinha(Linha linha);
     Task<Linha> UpdateLinha(int id, Linha linha);
     Task<Linha> DeleteLinha(int id);
     Task<Linha> FindByIdLinha(int id);
        Task<List<Linha>> GetAll();
        Task<List<Linha>> FindAllLinhasByParadas(int paradaId);
    }
}
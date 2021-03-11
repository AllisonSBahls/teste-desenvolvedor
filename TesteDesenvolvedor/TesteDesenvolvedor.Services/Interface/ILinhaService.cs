using System.Collections.Generic;
using System.Threading.Tasks;
using TesteDesenvolvedor.Domain;

namespace TesteDesenvolvedor.Services.Interface
{
    public interface ILinhaService
    {
        Task<Linha> FindByIdLinhaAsync(long id);
        Task<List<Linha>> GetAllLinhasAsync();
        Task<Linha> AddLinhaAsync(Linha linha);
        Task<Linha> UpdateLinhaAsync(long id, Linha linha);
        Task<bool> DeleteLinhaAsync(long id);
        Task<List<Linha>> FindAllLinhasByParadasAsync(long paradaId);

    }
}
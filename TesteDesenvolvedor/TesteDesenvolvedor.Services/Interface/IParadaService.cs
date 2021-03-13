using System.Collections.Generic;
using System.Threading.Tasks;
using TesteDesenvolvedor.Domain;
using TesteDesenvolvedor.Services.DTOs;

namespace TesteDesenvolvedor.Services.Interface
{
    public interface IParadaService
    {
        Task<ParadaDTO> FindByIdParadaAsync(long id);
        Task<List<ParadaDTO>> GetAllParadasAsync();
        Task<ParadaDTO> AddParadaAsync(Parada parada);
        Task<List<ParadaDTO>> FindParadaByPosicao(double lat, double lng, double distance);
        Task<ParadaDTO> UpdateParadaAsync(long id, ParadaDTO parada);
        Task<bool> DeleteParadaAsync(long id);
    }
}
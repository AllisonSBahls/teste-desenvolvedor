using System.Linq;
using AutoMapper;
using TesteDesenvolvedor.Domain;

namespace TesteDesenvolvedor.Services.DTOs
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Linha, LinhaDTO>()
                .ForMember(dest => dest.Paradas, opt => {
                    opt.MapFrom(src => src.LinhasParadas.Select(x => x.Parada).ToList());
                }).ReverseMap();

            CreateMap<Parada, ParadaDTO>() 
                .ForMember(dest => dest.Linhas, opt => {
                    opt.MapFrom(src => src.LinhaParadas.Select(x => x.Linha).ToList());
                }).ReverseMap();

            CreateMap<PosicaoVeiculo, PosicaoVeiculoDTO>().ReverseMap();
            
            CreateMap<Veiculo, VeiculoDTO>().ReverseMap();

            CreateMap<Linha, LinhaParadasDTO>().ReverseMap();

        }
    }
}
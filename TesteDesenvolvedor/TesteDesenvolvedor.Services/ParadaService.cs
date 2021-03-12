using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TesteDesenvolvedor.Domain;
using TesteDesenvolvedor.Repository.Interface;
using TesteDesenvolvedor.Services.DTOs;
using TesteDesenvolvedor.Services.Interface;

namespace TesteDesenvolvedor.Services
{
    public class ParadaService : IParadaService
    {
         private readonly IParadaRepository _repository;
         private readonly IMapper _mapper;
        public ParadaService(IParadaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ParadaDTO> FindByIdParadaAsync(long id)
        {
            try
            {
                var result = await _repository.FindByIdAsync(id);
                if (result == null) return null;

                return _mapper.Map<ParadaDTO>(result);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<ParadaDTO> AddParadaAsync(Parada parada)
        {
            try
            {
                // var parada = _mapper.Map<Parada>(paradaDTO);
                _repository.Add(parada);
                return await _repository.SaveChangesAsync() ?
                    _mapper.Map<ParadaDTO>(await _repository.FindByIdAsync(parada.Id)):
                    null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteParadaAsync(long id)
        {
           try{
               var result = await _repository.FindByIdAsync(id);
               if(result == null) throw new Exception("Parada não encontrada");

               _repository.Delete(result);
               return await _repository.SaveChangesAsync();

           }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ParadaDTO>> GetAllParadasAsync()
        {
           try{
               
               var result = await _repository.GetAllAsync();
               if (result == null) return null;
               return _mapper.Map<List<ParadaDTO>>(result);;

           }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ParadaDTO> UpdateParadaAsync(long id, ParadaDTO paradaDTO)
        {
            try{
                var parada = _mapper.Map<Parada>(paradaDTO);
                var result = await _repository.FindByIdAsync(id);
                                Console.WriteLine(result.Name);

                if (result == null) throw new Exception("Parada não encontrada");
                
                parada.Id = result.Id;
                _repository.Update(parada);
                if(await _repository.SaveChangesAsync()){
                    return _mapper.Map<ParadaDTO>(await _repository.FindByIdAsync(id));
                }
                return null;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteDesenvolvedor.Domain;
using TesteDesenvolvedor.Repository.Interface;
using TesteDesenvolvedor.Services.Interface;

namespace TesteDesenvolvedor.Services
{
    public class ParadaService : IParadaService
    {
         private readonly IParadaRepository _repository;
        public ParadaService(IParadaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Parada> FindByIdParadaAsync(long id)
        {
            try
            {
                var result = await _repository.FindByIdAsync(id);
                if (result == null) return null;

                return result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<Parada> AddParadaAsync(Parada parada)
        {
            try
            {
                _repository.Add(parada);
                return await _repository.SaveChangesAsync() ?
                    await _repository.FindByIdAsync(parada.Id) :
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

        public async Task<List<Parada>> GetAllParadasAsync()
        {
           try{
               
               var result = await _repository.GetAllAsync();
               if (result == null) return null;
               return result;

           }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Parada> UpdateParadaAsync(long id, Parada parada)
        {
            try{
                var result = await _repository.FindByIdAsync(id);
                if (result == null) throw new Exception("Parada não encontrada");

                parada.Id = result.Id;
                _repository.Update(parada);
                if(await _repository.SaveChangesAsync()){
                    return await _repository.FindByIdAsync(id);
                }
                return null;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
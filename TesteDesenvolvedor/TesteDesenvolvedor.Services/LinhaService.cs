using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteDesenvolvedor.Domain;
using TesteDesenvolvedor.Repository.Interface;
using TesteDesenvolvedor.Services.Interface;

namespace TesteDesenvolvedor.Services
{
    public class LinhaService : ILinhaService
    {
        private readonly ILinhaRepository _repository;
        public LinhaService(ILinhaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Linha> FindByIdLinhaAsync(long id)
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


        public async Task<Linha> AddLinhaAsync(Linha linha)
        {
            try
            {
                _repository.Add(linha);
                return await _repository.SaveChangesAsync() ?
                    await _repository.FindByIdAsync(linha.Id) :
                    null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteLinhaAsync(long id)
        {
           try{
               var result = await _repository.FindByIdAsync(id);
               if(result == null) throw new Exception("Linha não encontrada");

               _repository.Delete(result);
               return await _repository.SaveChangesAsync();

           }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Linha>> FindAllLinhasByParadasAsync(long paradaId)
        {
           try{

               var result = await _repository.FindAllLinhasByParadasAsync(paradaId);
               if (result == null) return null;
               return result;

           }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<Linha>> GetAllLinhasAsync()
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

        public async Task<Linha> UpdateLinhaAsync(long id, Linha linha)
        {
            try{
                var result = await _repository.FindByIdAsync(id);
                if (result == null) throw new Exception("Linha não encontrada");

                _repository.Update(result, linha);
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
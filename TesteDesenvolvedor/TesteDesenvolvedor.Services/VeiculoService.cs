using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteDesenvolvedor.Domain;
using TesteDesenvolvedor.Repository.Interface;
using TesteDesenvolvedor.Services.Interface;

namespace TesteDesenvolvedor.Services
{
    public class VeiculoService : IVeiculoService
    {
         private readonly IVeiculoRepository _repository;
        public VeiculoService(IVeiculoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Veiculo> FindByIdVeiculoAsync(long id)
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


        public async Task<Veiculo> AddVeiculoAsync(Veiculo veiculo)
        {
            try
            {
                _repository.Add(veiculo);
                return await _repository.SaveChangesAsync() ?
                    await _repository.FindByIdAsync(veiculo.Id) :
                    null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteVeiculoAsync(long id)
        {
           try{
               var result = await _repository.FindByIdAsync(id);
               if(result == null) throw new Exception("Veiculo não encontrado");

               _repository.Delete(result);
               return await _repository.SaveChangesAsync();

           }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Veiculo>> FindAllVeiculosByLinhasAsync(long linhaId)
        {
           try{

               var result = await _repository.FindAllVeiculosByLinhasAsync(linhaId);
               if (result == null) return null;
               return result;

           }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<Veiculo>> GetAllVeiculosAsync()
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

        public async Task<Veiculo> UpdateVeiculoAsync(long id, Veiculo veiculo)
        {
            try{
                var result = await _repository.FindByIdAsync(id);
                if (result == null) throw new Exception("Veiculo não encontrado");

                veiculo.Id = result.Id;
                _repository.Update(veiculo);
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
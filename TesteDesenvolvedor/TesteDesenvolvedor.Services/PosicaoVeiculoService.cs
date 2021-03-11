using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteDesenvolvedor.Domain;
using TesteDesenvolvedor.Repository.Interface;
using TesteDesenvolvedor.Services.Interface;

namespace TesteDesenvolvedor.Services
{
    public class PosicaoVeiculoService : IPosicaoVeiculoService
    {
          private readonly IPosicaoVeiculoRepository _repository;
        public PosicaoVeiculoService(IPosicaoVeiculoRepository repository)
        {
            _repository = repository;
        }
        public async Task<PosicaoVeiculo> FindByIdPosicaoVeiculoAsync(double id)
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


        public async Task<PosicaoVeiculo> AddPosicaoVeiculoAsync(PosicaoVeiculo posicaoVeiculo)
        {
            try
            {
                _repository.Add(posicaoVeiculo);
                return await _repository.SaveChangesAsync() ?
                    await _repository.FindByIdAsync(posicaoVeiculo.VeiculoId) :
                    null;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar a PosicaoVeiculo: " + ex.Message);
            }
        }

        public async Task<bool> DeletePosicaoVeiculoAsync(double veiculoId)
        {
           try{
               var result = await _repository.FindByIdAsync(veiculoId);
               if(result == null) throw new Exception("PosicaoVeiculo não encontrada");

               _repository.Delete(result);
               return await _repository.SaveChangesAsync();

           }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<PosicaoVeiculo>> GetAllPosicaoVeiculosAsync()
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

        public async Task<PosicaoVeiculo> UpdatePosicaoVeiculoAsync(double id, PosicaoVeiculo PosicaoVeiculo)
        {
            try{
                var result = await _repository.FindByIdAsync(id);
                if (result == null) throw new Exception("PosicaoVeiculo não encontrada");

                _repository.Update(result, PosicaoVeiculo);
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
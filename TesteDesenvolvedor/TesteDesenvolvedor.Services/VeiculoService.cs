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
    public class VeiculoService : IVeiculoService
    {
         private readonly IVeiculoRepository _repository;
         private readonly IMapper _mapper;

        public VeiculoService(IVeiculoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<VeiculoDTO> FindByIdVeiculoAsync(long id)
        {
            try
            {
                var result = await _repository.FindByIdAsync(id);
                if (result == null) return null;

                return _mapper.Map<VeiculoDTO>(result);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<VeiculoDTO> AddVeiculoAsync(VeiculoDTO veiculoDTO)
        {
            try
            {
                var veiculo = _mapper.Map<Veiculo>(veiculoDTO);
                _repository.Add(veiculo);
                return await _repository.SaveChangesAsync() ?
                    _mapper.Map<VeiculoDTO>(await _repository.FindByIdAsync(veiculo.Id)) :
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

        public async Task<List<VeiculoDTO>> FindAllVeiculosByLinhasAsync(long linhaId)
        {
           try{

               var result = await _repository.FindAllVeiculosByLinhasAsync(linhaId);
               if (result == null) return null;
               return _mapper.Map<List<VeiculoDTO>>(result);
               
           }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<VeiculoDTO>> GetAllVeiculosAsync()
        {
           try{
               
               var result = await _repository.GetAllAsync();
               if (result == null) return null;
               return _mapper.Map<List<VeiculoDTO>>(result);

           }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<VeiculoDTO> UpdateVeiculoAsync(long id, VeiculoDTO veiculoDTO)
        {
            try{
                var veiculo = _mapper.Map<Veiculo>(veiculoDTO);
                var result = await _repository.FindByIdAsync(id);
                if (result == null) throw new Exception("Veiculo não encontrado");

                veiculo.Id = result.Id;
                _repository.Update(veiculo);
                if(await _repository.SaveChangesAsync()){
                    return _mapper.Map<VeiculoDTO>(await _repository.FindByIdAsync(id));
                }
                return null;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
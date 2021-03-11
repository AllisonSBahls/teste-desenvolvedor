using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteDesenvolvedor.Domain;
using TesteDesenvolvedor.Services.Interface;

namespace TesteDesenvolvedor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PosicaoVeiculoController: ControllerBase
    {
        private readonly IPosicaoVeiculoService _service;

        public PosicaoVeiculoController(IPosicaoVeiculoService service)
        {
            _service = service;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id){
            try{
                var result = await _service.FindByIdPosicaoVeiculoAsync(id);
                if (result == null) return NotFound("Posicao do Veiculo não encontrada");

                return Ok(result);
            }catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno ao procurar a PosicaoVeiculo: {ex.Message} ");
            }
        }
        
       
        [HttpGet]
        public async Task<IActionResult> Get(){
            try{
                var result = await _service.GetAllPosicaoVeiculosAsync();
                if (result == null) return NotFound("Nenhuma PosicaoVeiculo encontrada");

                return Ok(result);
            }catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno ao procurar as PosicaoVeiculos: {ex.Message} ");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(PosicaoVeiculo posicaoVeiculo){
            try{
                var result = await _service.AddPosicaoVeiculoAsync(posicaoVeiculo);
                if(result == null) return BadRequest("Erro ao inserir a PosicaoVeiculo");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno ao cadastrar a PosicaoVeiculo: {ex.Message} ");
            }
        }

 
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, PosicaoVeiculo PosicaoVeiculo)
        {
            try
            {
                var result = await _service.UpdatePosicaoVeiculoAsync(id, PosicaoVeiculo);
                if (result == null) return BadRequest("Erro em procurar as informações da PosicaoVeiculo");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro em atualizar as informações da PosicaoVeiculo: {ex.Message} ");
            }
        }
         [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                return await _service.DeletePosicaoVeiculoAsync(id) ? 
                    Ok("Deletado") : 
                    BadRequest("Não foi possivel deletar a PosicaoVeiculo");
;
            }catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno ao deletar a PosicaoVeiculo: {ex.Message}");
            }
        }
    }
}
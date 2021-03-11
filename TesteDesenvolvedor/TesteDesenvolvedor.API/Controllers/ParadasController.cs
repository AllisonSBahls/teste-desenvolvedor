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
    public class ParadasController: ControllerBase
    {
        private readonly IParadaService _service;

        public ParadasController(IParadaService service)
        {
            _service = service;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id){
            try{
                var result = await _service.FindByIdParadaAsync(id);
                if (result == null) return NotFound("Parada não encontrada");

                return Ok(result);
            }catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno ao procurar a Parada: {ex.Message} ");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Parada parada){
            try{
                var result = await _service.AddParadaAsync(parada);
                if(result == null) return BadRequest("Erro ao cadastrar a Parada");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno ao cadastrar a Parada: {ex.Message} ");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, Parada parada)
        {
            try
            {
                var result = await _service.UpdateParadaAsync(id, parada);
                if (result == null) return BadRequest("Erro em alterar os dados da Parada");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro em atualizar as informações da parada: {ex.Message} ");
            }
        }
    }
}
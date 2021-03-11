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
    public class LinhasController : ControllerBase
    {
        private readonly ILinhaService _service;

        public LinhasController(ILinhaService service)
        {
            _service = service;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id){
            try{
                var result = await _service.FindByIdLinhaAsync(id);
                if (result == null) return NotFound("Linha não encontrada");

                return Ok(result);
            }catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno ao procurar a linha: {ex.Message} ");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Linha linha){
            try{
                var result = await _service.AddLinhaAsync(linha);
                if(result == null) return BadRequest("Erro ao cadastrar a linha");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno ao cadastrar a linha: {ex.Message} ");
            }
        }
    }
}
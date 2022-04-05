using DesafioBackEnd.Entidades;
using DesafioBackEnd.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace DesafioBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SensorController : Controller
    {
        private readonly ISensorRepositorio _sensorRepositorio;

        public SensorController(ISensorRepositorio sensorRepositorio)
        {
            _sensorRepositorio = sensorRepositorio;
        }
        [HttpGet]
        [Route("")]
        public virtual async Task<IActionResult> Listar()
        {
            try
            {
                var list = await _sensorRepositorio.BuscarTodos();
                return new OkObjectResult(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public virtual async Task<IActionResult> SelecionarPorId(int id)
        {
            try
            {
                var objById = await _sensorRepositorio.BuscarPorId(id);
                return new OkObjectResult(objById);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public virtual async Task<IActionResult> Incluir([FromBody] Sensor dado)
        {
            try
            {
                return new OkObjectResult(await _sensorRepositorio.Incluir(dado));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public virtual async Task<IActionResult> Alterar([FromBody] Sensor dado)
        {
            try
            {
                await _sensorRepositorio.Alterar(dado);
                return new OkObjectResult(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            try
            {
                await _sensorRepositorio.Excluir(id);
                return new OkObjectResult(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

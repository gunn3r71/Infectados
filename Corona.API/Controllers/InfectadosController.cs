using Corona.API.Data;
using Corona.API.Data.Collections;
using Corona.API.Models;
using Corona.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Corona.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfectadosController : ControllerBase
    {
        private readonly IInfectadoService _mongoService;

        public InfectadosController(IInfectadoService mongoService)
        {
            _mongoService = mongoService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosInfectados()
        {
            return Ok(await _mongoService.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var result = _mongoService.ObterPorId(id);

            if (result is not null)
            {
                return NotFound(new
                {
                    Message = "Infectado não foi encontrado."
                });
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarInfectado([FromBody] InfectadoDTO infectadoModel)
        {
            var infectado = new Infectado(infectadoModel.DataNascimento,
               infectadoModel.Sexo,
               infectadoModel.Latitude,
               infectadoModel.Longitude);

            await _mongoService.Adicionar(infectado);

            return CreatedAtRoute("", new { Id = infectado.Id }, infectado);
        }
    }
}

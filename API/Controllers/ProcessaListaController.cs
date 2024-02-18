using Application.Enums;
using Desafio.Application.Service.Processamento.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessaListaController : ControllerBase
    {
        [HttpPost("ObterListaOrdenada")]
        public IActionResult ObterListaOrdenada(
            [FromBody] ICollection<Familia> listaFamilias,
            [FromServices] IProcessaContexto processaContexto,
            [FromServices] IProcessaFabrica processaFabrica)
        {
            if (listaFamilias == null || listaFamilias.Count == 0)
                return BadRequest("Informação inválida!");

            var familias = listaFamilias;

            foreach (var estrategia in Enum.GetValues(typeof(Estrategia)))
            {
                IProcessaEstrategia processaEstrategia = processaFabrica.ObterEstrategia((Estrategia) estrategia);

                ICollection<Familia> novaLista = processaContexto
                    .DefineEstrategia(processaEstrategia)
                    .ProcessaInformacao(familias);

                familias = novaLista;
            }

            return Ok(familias.OrderByDescending(p => p.PontuacaoAcumulada));
        }
    }
}
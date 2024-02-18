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
        [HttpGet("ObterLista")]
        public IActionResult ObterLista(
            ICollection<Pessoa> listaFamilias,
            [FromServices] IProcessaContexto processaContexto,
            [FromServices] IProcessaFabrica processaFabrica)
        {
            var familias = listaFamilias;

            foreach (var estrategia in Enum.GetValues(typeof(Estrategia)))
            {
                IProcessaEstrategia processaEstrategia = processaFabrica.ObterEstrategia((Estrategia) estrategia);

                ICollection<Pessoa> novaLista = processaContexto
                    .DefineEstrategia(processaEstrategia)
                    .ProcessaInformacao(familias);

                familias = novaLista;
            }

            return Ok(familias.OrderBy(p => p.PontuacaoAcumulada));
        }
    }
}
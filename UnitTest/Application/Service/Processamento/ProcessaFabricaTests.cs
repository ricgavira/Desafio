using Application.Enums;
using Desafio.Application.Service.Processamento;

namespace Desafio.Test.Application.Service.Processamento
{
    public class ProcessaFabricaTests
    {


        [Theory(DisplayName = "Deve instanciar cada classe especificada no Theory.")]
        [InlineData(Estrategia.PorRenda, typeof(ProcessaRenda))]
        [InlineData(Estrategia.PorDependentes, typeof(ProcessaDependentes))]
        public void DeveInstanciarAsClassesEspecificadas(Estrategia estrategia, Type tipoEsperado)
        {
            var fabrica = new ProcessaFabrica();

            var estrategiaRetornada = fabrica.ObterEstrategia(estrategia);

            Assert.IsType(tipoEsperado, estrategiaRetornada);
        }

        [Fact(DisplayName = "Deve lançar uma exceção de argumento inválido.")]
        public void DeveLancarExcecaoDeArgumentoInvalido()
        {
            var fabrica = new ProcessaFabrica();

            Assert.Throws<ArgumentException>(() => fabrica.ObterEstrategia((Estrategia)5));
        }
    }
}

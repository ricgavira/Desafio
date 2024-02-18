using Application;
using Application.Enums;
using Desafio.Application.Service.Processamento;
using Desafio.Application.Utils;
using Desafio.Domain.Entities;
using Domain.Entities;
using Domain.Enums;

namespace Desafio.Test.Application.Service.Processamento
{
    public class ProcessaContextoTests
    {
        [Fact(DisplayName = "Deve retornar 2 pontos por familia.")]
        public void DeveRetornar2PontosPorFamilia()
        {
            var familias = Setup();

            var familiasSelecionadas = SetupPorEstrategia(familias, Estrategia.PorDependentes);

            Assert.NotNull(familiasSelecionadas);

            foreach (var familia in familiasSelecionadas)
            {
                Assert.Equal(2, familia.PontuacaoAcumulada);
            }
        }

        [Fact(DisplayName = "Deve retornar uma das familias com 7 pontos acumulados")]
        public void DeveRetornarUmaFamiliaCom7PntosAcumulados()
        {
            var familias = Setup();

            var familiasSelecionadasPorRenda = SetupPorEstrategia(familias, Estrategia.PorRenda);
            var familiasSelecionadas = SetupPorEstrategia(familiasSelecionadasPorRenda, Estrategia.PorDependentes);

            Assert.NotNull(familiasSelecionadas);

            Assert.NotEmpty(familiasSelecionadas.Where(x => x.PontuacaoAcumulada == 7));
            Assert.Equal(7, familiasSelecionadas.Where(x => x.PontuacaoAcumulada == 7).Single().PontuacaoAcumulada);
        }

        private ICollection<Familia> SetupPorEstrategia(ICollection<Familia> familias, Estrategia estrategia)
        {
            var fabrica = new ProcessaFabrica();
            var estrategiaRetornada = fabrica.ObterEstrategia(estrategia);
            var contexto = new ProcessaContexto();

            contexto.DefineEstrategia(estrategiaRetornada);

            return contexto.ProcessaInformacao(familias);
        }

        private ICollection<Familia> Setup()
        {
            List<Familia> familias = new List<Familia>();

            Familia familia1 = new Familia(1, new List<Familiares>());
            familia1.Familiares.Add(new Familiares("Ricardo", 1900.00, Utilitarios.CalcularDataNascimentoPelaIdade(44), Classificacao.Pai, Sexo.Masculino));
            familia1.Familiares.Add(new Familiares("Cassia", 500.00, Utilitarios.CalcularDataNascimentoPelaIdade(43), Classificacao.Mae, Sexo.Feminino));
            familia1.Familiares.Add(new Familiares("Yasmin", 0.00, Utilitarios.CalcularDataNascimentoPelaIdade(13), Classificacao.Filha, Sexo.Feminino));
            familia1.Familiares.Add(new Familiares("Luiza", 0.00, Utilitarios.CalcularDataNascimentoPelaIdade(10), Classificacao.Filha, Sexo.Feminino));

            familias.Add(familia1);

            Familia familia2 = new Familia(2, new List<Familiares>());
            familia2.Familiares.Add(new Familiares("João", 500.00, Utilitarios.CalcularDataNascimentoPelaIdade(46), Classificacao.Pai, Sexo.Masculino));
            familia2.Familiares.Add(new Familiares("Maria", 300.00, Utilitarios.CalcularDataNascimentoPelaIdade(50), Classificacao.Mae, Sexo.Feminino));
            familia2.Familiares.Add(new Familiares("Jose", 0.00, Utilitarios.CalcularDataNascimentoPelaIdade(5), Classificacao.Filho, Sexo.Masculino));
            familia2.Familiares.Add(new Familiares("Pedro", 100.00, Utilitarios.CalcularDataNascimentoPelaIdade(24), Classificacao.Filho, Sexo.Masculino));

            familias.Add(familia2);

            return familias;
        }
    }
}
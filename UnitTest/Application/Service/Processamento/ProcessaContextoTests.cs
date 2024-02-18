using Application;
using Application.Enums;
using Desafio.Application.Service.Processamento;
using Domain.Entities;
using Domain.Enums;

namespace Desafio.Test.Application.Service.Processamento
{
    public class ProcessaContextoTests
    {
        [Fact(DisplayName = "Deve processar, filtrar a lista passada e retornar com menos objetos.")]
        public void DeveProcessarFiltrarERetornarALista()
        {
            var familias = Setup();

            var familiasSelecionadas = SetupPorEstrategia(familias, Estrategia.PorRenda);

            Assert.NotNull(familiasSelecionadas);
            Assert.NotEqual(familias.Count, familiasSelecionadas.Count);
        }

        [Fact(DisplayName = "Deve calcular a primeira faixa de pontos para a familia retornada utilizando a estrategia por renda.")]
        public void DeveCalcularPrimeiraFaixaDePontosParaFamiliaRetornadaNaEstrategiaRenda()
        {
            var familias = Setup();

            var familiasSelecionadas = SetupPorEstrategia(familias, Estrategia.PorRenda);
            
            Assert.NotNull(familiasSelecionadas);
            Assert.NotEmpty(familiasSelecionadas);
            Assert.Equal(Configuracao.PontosRendaFamiliarAte900Reais, familiasSelecionadas.Single().PontuacaoAcumulada);
        }

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

        [Fact(DisplayName = "Deve retornar uma familia com 7 pontos acumulados")]
        public void DeveRetornarUmaFamiliaCom7PntosAcumulados()
        {
            var familias = Setup();

            var familiasSelecionadasPorRenda = SetupPorEstrategia(familias, Estrategia.PorRenda);
            var familiasSelecionadas = SetupPorEstrategia(familiasSelecionadasPorRenda, Estrategia.PorDependentes);

            Assert.NotNull(familiasSelecionadas);
            Assert.Equal(7, familiasSelecionadas.Single().PontuacaoAcumulada);
        }

        private ICollection<Pessoa> SetupPorEstrategia(ICollection<Pessoa> familias, Estrategia estrategia)
        {
            var fabrica = new ProcessaFabrica();
            var estrategiaRetornada = fabrica.ObterEstrategia(estrategia);
            var contexto = new ProcessaContexto();

            contexto.DefineEstrategia(estrategiaRetornada);

            return contexto.ProcessaInformacao(familias);
        }

        private ICollection<Pessoa> Setup()
        {
            List<Pessoa> familias = new List<Pessoa>();

            Pessoa familia1 = new Pessoa("Ricardo", 1900.00, new DateTime(1980, 06, 19), Classificacao.Pai, Sexo.Masculino);
            familia1.Dependentes.Add(new Pessoa("Cassia", 500.00, new DateTime(1980, 11, 11), Classificacao.Mae, Sexo.Feminino));
            familia1.Dependentes.Add(new Pessoa("Yasmin", 0.00, new DateTime(2011, 05, 06), Classificacao.Filha, Sexo.Feminino));
            familia1.Dependentes.Add(new Pessoa("Luiza", 0.00, new DateTime(2014, 06, 16), Classificacao.Filha, Sexo.Feminino));

            familias.Add(familia1);

            Pessoa familia2 = new Pessoa("João", 500.00, new DateTime(1975, 09, 25), Classificacao.Pai, Sexo.Masculino);
            familia2.Dependentes.Add(new Pessoa("Maria", 300.00, new DateTime(1972, 10, 19), Classificacao.Mae, Sexo.Feminino));
            familia2.Dependentes.Add(new Pessoa("Jose", 0.00, new DateTime(2019, 08, 06), Classificacao.Filho, Sexo.Masculino));
            familia2.Dependentes.Add(new Pessoa("Pedro", 100.00, new DateTime(2000, 08, 16), Classificacao.Filho, Sexo.Masculino));

            familias.Add(familia2);

            return familias;
        }
    }
}
using Desafio.Application.Service.Processamento;
using Domain.Entities;
using Domain.Enums;

namespace Desafio.Test.Application.Service.Processamento
{
    public class ProcessaRendaTests
    {
        [Fact(DisplayName = "Deve retornar somente uma familia habilitada.")]
        public void DeveRetornarSomenteUmaFamiliaHabilitada()
        {
            var familias = Setup();

            var porRenda = new ProcessaRenda();
            var resultado = porRenda.ProcessaInformacao(familias);

            Assert.NotNull(resultado);
            Assert.Equal(1, resultado.Count);
        }

        [Fact(DisplayName = "Deve retornar uma familia com 7 pontos")]
        public void DeveRetornarUmaFamiliaComPontuacao7()
        {
            List<Pessoa> familias = new List<Pessoa>();

            Pessoa familia = new Pessoa("Cassia", 900.00, new DateTime(1980, 11, 11), Classificacao.Mae, Sexo.Feminino);
            familia.AlteraDataAtual(new DateTime(2024, 02, 18));
            familia.Dependentes.Add(new Pessoa("Yasmin", 0.00, new DateTime(2011, 05, 06), Classificacao.Filha, Sexo.Feminino));
            familia.Dependentes.Add(new Pessoa("Luiza", 100.00, new DateTime(2000, 06, 16), Classificacao.Filha, Sexo.Feminino));

            familias.Add(familia);

            var porRenda = new ProcessaRenda();
            porRenda.DefinePontuacao(familias);

            Assert.Equal(7, familias.Single().PontuacaoAcumulada);
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

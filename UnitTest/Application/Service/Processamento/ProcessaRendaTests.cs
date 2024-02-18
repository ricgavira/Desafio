using Application;
using Desafio.Application.Service.Processamento;
using Desafio.Application.Utils;
using Desafio.Domain.Entities;
using Domain.Entities;
using Domain.Enums;

namespace Desafio.Test.Application.Service.Processamento
{
    public class ProcessaRendaTests
    {
        [Fact(DisplayName = "Deve retornar somente uma familia com pontuação.")]
        public void DeveRetornarSomenteUmaFamiliaHabilitada()
        {
            var familias = Setup();

            var porRenda = new ProcessaRenda();
            var resultado = porRenda.ProcessaInformacao(familias);

            Assert.NotNull(resultado);
            Assert.Equal(1, resultado.Count(x => x.PontuacaoAcumulada > 0));
        }

        [Fact(DisplayName = "Deve retornar uma familia com 7 pontos")]
        public void DeveRetornarUmaFamiliaComPontuacao7()
        {
            List<Familia> familias = new List<Familia>();

            Familia familia = new Familia(1, new List<Familiares>());
            familia.Familiares.Add(new Familiares("Cassia", 900.00, Utilitarios.CalcularDataNascimentoPelaIdade(43), Classificacao.Mae, Sexo.Feminino));
            familia.Familiares.Add(new Familiares("Yasmin", 0.00, Utilitarios.CalcularDataNascimentoPelaIdade(13), Classificacao.Filha, Sexo.Feminino));
            familia.Familiares.Add(new Familiares("Luiza", 100.00, Utilitarios.CalcularDataNascimentoPelaIdade(24), Classificacao.Filha, Sexo.Feminino));

            familias.Add(familia);

            var porRenda = new ProcessaRenda();
            porRenda.DefinePontuacao(familias);

            Assert.Equal(Configuracao.PontosRendaFamiliarAte900Reais, familias.Single().PontuacaoAcumulada);
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

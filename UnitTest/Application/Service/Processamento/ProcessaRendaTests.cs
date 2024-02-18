using Application;
using Desafio.Application.Service.Processamento;
using Desafio.Application.Utils;
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

            Pessoa familia = new Pessoa("Cassia", 900.00, Utilitarios.CalcularDataNascimentoPelaIdade(43), Classificacao.Mae, Sexo.Feminino);
            familia.Dependentes.Add(new Pessoa("Yasmin", 0.00, Utilitarios.CalcularDataNascimentoPelaIdade(13), Classificacao.Filha, Sexo.Feminino));
            familia.Dependentes.Add(new Pessoa("Luiza", 100.00, Utilitarios.CalcularDataNascimentoPelaIdade(24), Classificacao.Filha, Sexo.Feminino));

            familias.Add(familia);

            var porRenda = new ProcessaRenda();
            porRenda.DefinePontuacao(familias);

            Assert.Equal(Configuracao.PontosRendaFamiliarAte900Reais, familias.Single().PontuacaoAcumulada);
        }

        private ICollection<Pessoa> Setup()
        {
            List<Pessoa> familias = new List<Pessoa>();

            Pessoa familia1 = new Pessoa("Ricardo", 1900.00, Utilitarios.CalcularDataNascimentoPelaIdade(44), Classificacao.Pai, Sexo.Masculino);
            familia1.Dependentes.Add(new Pessoa("Cassia", 500.00, Utilitarios.CalcularDataNascimentoPelaIdade(43), Classificacao.Mae, Sexo.Feminino));
            familia1.Dependentes.Add(new Pessoa("Yasmin", 0.00, Utilitarios.CalcularDataNascimentoPelaIdade(13), Classificacao.Filha, Sexo.Feminino));
            familia1.Dependentes.Add(new Pessoa("Luiza", 0.00, Utilitarios.CalcularDataNascimentoPelaIdade(10), Classificacao.Filha, Sexo.Feminino));

            familias.Add(familia1);

            Pessoa familia2 = new Pessoa("João", 500.00, Utilitarios.CalcularDataNascimentoPelaIdade(46), Classificacao.Pai, Sexo.Masculino);
            familia2.Dependentes.Add(new Pessoa("Maria", 300.00, Utilitarios.CalcularDataNascimentoPelaIdade(50), Classificacao.Mae, Sexo.Feminino));
            familia2.Dependentes.Add(new Pessoa("Jose", 0.00, Utilitarios.CalcularDataNascimentoPelaIdade(5), Classificacao.Filho, Sexo.Masculino));
            familia2.Dependentes.Add(new Pessoa("Pedro", 100.00, Utilitarios.CalcularDataNascimentoPelaIdade(24), Classificacao.Filho, Sexo.Masculino));

            familias.Add(familia2);

            return familias;
        }
    }
}

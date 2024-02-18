using Desafio.Application.Utils;
using Desafio.Domain.Entities;
using Domain.Entities;
using Domain.Enums;

namespace UnitTest.Domain.Entities
{
    public class PessoaTests
    {
        [Fact(DisplayName = "Deve criar uma familia com familiares sem erros.")]
        public void DeveCriarPessoaEDependenteSemErros()
        {
            Familia familia = Setup();

            Assert.NotNull(familia);
            Assert.NotEmpty(familia.Familiares);
        }

        [Fact(DisplayName = "Deve retornar false e a mensagem de erro quando não informado o nome na criação da pessoa.")]
        public void DeveRetornarFalseEMensagemQuandoNomeForNulo()
        {
            Familia familia = new Familia(1, new List<Familiares>());
            familia.Familiares.Add(new Familiares(null, 1000.00, Utilitarios.CalcularDataNascimentoPelaIdade(13), Classificacao.Filha, Sexo.Feminino));

            var resultado = familia.ValidateFamiliares();

            Assert.False(resultado.Item1);
            Assert.Equal("Informe o nome da pessoa!", resultado.Item2);
        }

        private Familia Setup()
        {
            var familia = new Familia(1, new List<Familiares>());
            familia.Familiares.Add(new Familiares("Ricardo", 5000.00, Utilitarios.CalcularDataNascimentoPelaIdade(43), Classificacao.Pai, Sexo.Masculino));
            familia.Familiares.Add(new Familiares("Yasmin", 1000.00, Utilitarios.CalcularDataNascimentoPelaIdade(13), Classificacao.Filha, Sexo.Feminino));
            return familia;
        }
    }
}
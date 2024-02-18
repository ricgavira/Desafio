using Domain.Entities;
using Domain.Enums;

namespace UnitTest.Domain.Entities
{
    public class PessoaTests
    {
        private string nome = "Ricardo";
        private double renda = 5000.00;
        private DateTime dataNascimento = DateTime.Parse("1981-05-19");
        private Classificacao classificacao = Classificacao.Pai;
        private Sexo sexo = Sexo.Masculino;


        [Fact(DisplayName = "Deve criar uma pessoa com todos os argumentos e não pode ocorrer erros.")]
        public void DeveCriarPessoaComTodosArgumentosSemErros()
        {
            Pessoa pessoa = Setup();

            Assert.NotNull(pessoa);
        }

        [Fact(DisplayName = "Deve criar uma pessoa e um dependente sem erros.")]
        public void DeveCriarPessoaEDependenteSemErros()
        {
            Pessoa pessoa = Setup();
            Pessoa dependente = new Pessoa("Yasmin", 1000.00, DateTime.Parse("2010-08-06"), Classificacao.Filha, Sexo.Feminino);

            pessoa.Dependentes.Add(dependente);

            Assert.NotNull(pessoa);
            Assert.NotEmpty(pessoa.Dependentes);
        }

        [Fact(DisplayName = "Deve retornar false e a mensagem de erro quando não informado o nome na criação da pessoa.")]
        public void DeveRetornarFalseEMensagemQuandoNomeForNulo()
        {
            Pessoa pessoa = new Pessoa(null, 1000.00, DateTime.Parse("2010-08-06"), Classificacao.Filha, Sexo.Feminino);

            var resultado = pessoa.Validate();

            Assert.False(resultado.Item1);
            Assert.Equal("Informe o nome da pessoa!", resultado.Item2);
        }

        private Pessoa Setup()
        {
            return new Pessoa(nome, renda, dataNascimento, classificacao, sexo);
        }
    }
}
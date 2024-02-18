using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Pessoa
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public double Renda { get; private set; }
        public DateTime DataNascimento { get; private set; }
        [NotMapped]
        public int Idade { get { return DateTime.Today.Year - DataNascimento.Year; } }
        public DateTime DataCadastro { get; private set; }
        [NotMapped]
        public double RendaTotalFamiliar { get; private set; }
        [NotMapped]
        public int PontuacaoAcumulada { get; private set; }
        public Classificacao Classificacao { get; private set; }
        public Sexo Sexo { get; private set; }
        public ICollection<Pessoa> Dependentes { get; private set; } = new List<Pessoa>();

        public Pessoa(string nome, double renda, DateTime dataNascimento, Classificacao classificacao, Sexo sexo)
        {
            Id = 0;
            Nome = nome;
            Renda = renda;
            DataNascimento = dataNascimento;
            Classificacao = classificacao;
            Sexo = sexo;
            DataCadastro = DateTime.Now;
        }

        public void AlteraDependentes(ICollection<Pessoa> dependentes)
        {
            this.Dependentes = dependentes;
        }

        public void AlteraRendaTotalFamiliar(double rendaTotal)
        {
            this.RendaTotalFamiliar = rendaTotal;
        }

        public void AlteraPontuacaoAcumulada(int pontos)
        {
            this.PontuacaoAcumulada = pontos;
        }

        public (bool, string) Validate()
        {
            if (string.IsNullOrEmpty(this.Nome))
                return (false, "Informe o nome da pessoa!");

            if (this.Renda.Equals(0))
                return (false, "Informe a renda da pessoa!");

            if (this.DataNascimento >= DateTime.Now)
                return (false, "Informe a data de nascimento da pessoa!");

            return (true, "Validado");
        }
    }
}

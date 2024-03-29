﻿using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio.Domain.Entities
{
    public class Familiares
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public double Renda { get; private set; }
        public DateTime DataNascimento { get; private set; }
        [NotMapped]
        public int Idade { get { return DateTime.Today.Year - DataNascimento.Year; } }
        public DateTime DataCadastro { get; private set; }
        public Classificacao Classificacao { get; private set; }
        public Sexo Sexo { get; private set; }

        public Familiares(string nome, double renda, DateTime dataNascimento, Classificacao classificacao, Sexo sexo)
        {
            Id = 0;
            Nome = nome;
            Renda = renda;
            DataNascimento = dataNascimento;
            Classificacao = classificacao;
            Sexo = sexo;
            DataCadastro = DateTime.Now;
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
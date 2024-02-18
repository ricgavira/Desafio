using Desafio.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Familia
    {
        public int Id { get; private set; }
        [NotMapped]
        public double RendaTotalFamiliar { get; private set; }
        [NotMapped]
        public int PontuacaoAcumulada { get; private set; }
        public ICollection<Familiares> Familiares { get; private set; }

        public Familia(int id, ICollection<Familiares> familiares)
        {
            Id = id;
            Familiares = familiares;
        }

        public void AlteraFamiliares(ICollection<Familiares> familiares)
        {
            this.Familiares = familiares;
        }

        public void AlteraRendaTotalFamiliar(double rendaTotal)
        {
            this.RendaTotalFamiliar = rendaTotal;
        }

        public void AlteraPontuacaoAcumulada(int pontos)
        {
            this.PontuacaoAcumulada = pontos;
        }

        public (bool, string) ValidateFamiliares()
        {
            foreach (var familiar in Familiares)
            {
                if (!familiar.Validate().Item1)
                    return familiar.Validate();
            }
            return (true, "Validado!");
        }             
    }
}
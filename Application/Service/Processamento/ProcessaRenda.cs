using Application;
using Desafio.Application.Service.Processamento.Interface;
using Domain.Entities;

namespace Desafio.Application.Service.Processamento
{
    public class ProcessaRenda : IProcessaEstrategia
    {
        public ICollection<Familia> ProcessaInformacao(ICollection<Familia> familias)
        {
            DefineRendaTotalFamiliar(familias);
            DefinePontuacao(familias);
            return familias.ToList();
        }

        private void DefineRendaTotalFamiliar(ICollection<Familia> familias)
        {
            foreach (var familia in familias)
            {
                double total = familia.Familiares.Sum(d => d.Renda);

                familia.AlteraRendaTotalFamiliar(total);
            }
        }

        public void DefinePontuacao(ICollection<Familia> familias)
        {
            foreach (var familia in familias)
            {
                int pontos = familia.PontuacaoAcumulada;

                switch (familia.RendaTotalFamiliar)
                {
                    case double valor when valor <= Configuracao.PrimeiraFaixaRenda:
                        pontos += Configuracao.PontosRendaFamiliarAte900Reais;
                        break;
                    case double valor when valor > Configuracao.PrimeiraFaixaRenda && valor <= Configuracao.SegundaFaixaRenda:
                        pontos += Configuracao.PontosRendaFamiliarAte1500Reais;
                        break;
                    default:
                        pontos = 0;
                        break;
                }

                familia.AlteraPontuacaoAcumulada(pontos);
            }
        }
    }
}
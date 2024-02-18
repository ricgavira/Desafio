using Application;
using Desafio.Application.Service.Processamento.Interface;
using Domain.Entities;

namespace Desafio.Application.Service.Processamento
{
    public class ProcessaRenda : IProcessaEstrategia
    {
        public ICollection<Pessoa> ProcessaInformacao(ICollection<Pessoa> familias)
        {
            DefineRendaTotalFamiliar(familias);
            DefinePontuacao(familias);
            return familias.Where(p => p.PontuacaoAcumulada > 0).ToList();
        }

        private void DefineRendaTotalFamiliar(ICollection<Pessoa> familias)
        {
            foreach (var familia in familias)
            {
                double total = familia.Renda;

                total += familia.Dependentes.Sum(d => d.Renda);

                familia.AlteraRendaTotalFamiliar(total);
            }
        }

        public void DefinePontuacao(ICollection<Pessoa> familias)
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
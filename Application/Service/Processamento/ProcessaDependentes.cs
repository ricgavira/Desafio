using Application;
using Desafio.Application.Service.Processamento.Interface;
using Domain.Entities;

namespace Desafio.Application.Service.Processamento
{
    public class ProcessaDependentes : IProcessaEstrategia
    {
        ICollection<Pessoa> IProcessaEstrategia.ProcessaInformacao(ICollection<Pessoa> familias)
        {
            List<Pessoa> familiasSelecionadas = familias
                .Where(p => p.Dependentes.Any(d => d.Idade <= Configuracao.IdadeMaximaDependentes))
                .ToList();

            DefinePontuacao(familiasSelecionadas);
            return familiasSelecionadas;
        }

        public void DefinePontuacao(ICollection<Pessoa> familias)
        {
            foreach (var familia in familias)
            {
                int ponto = familia.PontuacaoAcumulada;

                switch (familia.Dependentes.Where(d => d.Idade <= Configuracao.IdadeMaximaDependentes).Count())
                {
                    case int valor when valor >= Configuracao.PontosPrimeiraFaixaDependentes:
                        ponto += Configuracao.PontosFamiliaCom3OuMaisDependentes;
                        break;
                    case int valor when valor < Configuracao.PontosPrimeiraFaixaDependentes:
                        ponto += Configuracao.PontosFamiliaComMenosDe3Dependentes;
                        break;
                    default:
                        ponto = 0;
                        break;
                }

                familia.AlteraPontuacaoAcumulada(ponto);
            }
        }
    }
}
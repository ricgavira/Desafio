using Application;
using Desafio.Application.Service.Processamento.Interface;
using Domain.Entities;

namespace Desafio.Application.Service.Processamento
{
    public class ProcessaFamiliares : IProcessaEstrategia
    {
        ICollection<Familia> IProcessaEstrategia.ProcessaInformacao(ICollection<Familia> familias)
        {
            DefinePontuacao(familias);
            return familias;
        }

        public void DefinePontuacao(ICollection<Familia> familias)
        {
            foreach (var familia in familias)
            {
                int ponto = familia.PontuacaoAcumulada;

                switch (familia.Familiares.Where(d => d.Idade <= Configuracao.IdadeMaximaDependentes).Count())
                {
                    case int valor when valor >= Configuracao.PrimeiraFaixaDependentes:
                        ponto += Configuracao.PontosFamiliaCom3OuMaisDependentes;
                        break;
                    case int valor when valor < Configuracao.PrimeiraFaixaDependentes:
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
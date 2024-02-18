using Application.Enums;
using Desafio.Application.Service.Processamento.Interface;

namespace Desafio.Application.Service.Processamento
{
    public class ProcessaFabrica : IProcessaFabrica
    {
        public IProcessaEstrategia ObterEstrategia(Estrategia estrategia)
        {
            IProcessaEstrategia processaEstrategia;

            switch (estrategia)
            {
                case Estrategia.PorRenda:
                    processaEstrategia = new ProcessaRenda();
                    break;
                case Estrategia.PorDependentes:
                    processaEstrategia = new ProcessaFamiliares();
                    break;
                default:
                    throw new ArgumentException("Estratégia indefinida!");
            }

            return processaEstrategia;
        }
    }
}

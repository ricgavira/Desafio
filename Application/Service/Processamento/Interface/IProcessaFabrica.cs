using Application.Enums;

namespace Desafio.Application.Service.Processamento.Interface
{
    public interface IProcessaFabrica
    {
        IProcessaEstrategia ObterEstrategia(Estrategia estrategia);
    }
}
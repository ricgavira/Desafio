using Domain.Entities;

namespace Desafio.Application.Service.Processamento.Interface
{
    public interface IProcessaContexto
    {
        ICollection<Familia> ProcessaInformacao(ICollection<Familia> familias);
        IProcessaContexto DefineEstrategia(IProcessaEstrategia processaEstrategia);
    }
}

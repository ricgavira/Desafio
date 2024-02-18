using Domain.Entities;

namespace Desafio.Application.Service.Processamento.Interface
{
    public interface IProcessaContexto
    {
        ICollection<Pessoa> ProcessaInformacao(ICollection<Pessoa> familias);
        IProcessaContexto DefineEstrategia(IProcessaEstrategia processaEstrategia);
    }
}

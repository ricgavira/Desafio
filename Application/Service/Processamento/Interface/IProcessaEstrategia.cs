using Domain.Entities;

namespace Desafio.Application.Service.Processamento.Interface
{
    public interface IProcessaEstrategia
    {
        ICollection<Pessoa> ProcessaInformacao(ICollection<Pessoa> familias);
        void DefinePontuacao(ICollection<Pessoa> familias);
    }
}
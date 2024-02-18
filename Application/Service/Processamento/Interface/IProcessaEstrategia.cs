using Domain.Entities;

namespace Desafio.Application.Service.Processamento.Interface
{
    public interface IProcessaEstrategia
    {
        ICollection<Familia> ProcessaInformacao(ICollection<Familia> familias);
        void DefinePontuacao(ICollection<Familia> familias);
    }
}
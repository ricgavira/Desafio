using Desafio.Application.Service.Processamento.Interface;
using Domain.Entities;

namespace Desafio.Application.Service.Processamento
{
    public class ProcessaContexto : IProcessaContexto
    {
        private IProcessaEstrategia _processaEstrategia;

        public ProcessaContexto()
        {
            _processaEstrategia = new ProcessaRenda();
        }

        public IProcessaContexto DefineEstrategia(IProcessaEstrategia processaEstrategia)
        {
            _processaEstrategia = processaEstrategia;
            return this;
        }

        public ICollection<Familia> ProcessaInformacao(ICollection<Familia> pessoas)
        {
            var result = _processaEstrategia.ProcessaInformacao(pessoas);
            return result;
        }
    }
}
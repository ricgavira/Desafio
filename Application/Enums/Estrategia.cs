using System.ComponentModel;

namespace Application.Enums
{
    public enum Estrategia
    {
        [Description("Tipo de estratégia por renda familiar")]
        PorRenda = 0,
        [Description("Tipo de estratégia por quantidade de dependentes")]
        PorDependentes = 1
    }
}

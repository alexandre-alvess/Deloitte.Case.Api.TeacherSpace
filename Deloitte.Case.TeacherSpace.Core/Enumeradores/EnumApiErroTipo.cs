using System.ComponentModel;

namespace Deloitte.Case.TeacherSpace.Core.Enumeradores
{
    /// <summary>
    /// Define o enumerador <see cref="EnumApiErroTipo"/>.
    /// </summary>
    public enum EnumApiErroTipo
    {
        [Description("Comunicacao")]
        Comunicacao,

        [Description("Negócio")]
        Negocio,

        [Description("Técnico")]
        Tecnico,

        [Description("Outro")]
        Outro
    }
}

namespace Deloitte.Case.TeacherSpace.Core.Excecoes
{
    /// <summary>
    /// Define a classe <see cref="ExternoApiException"/>.
    /// </summary>
    public class ExternoApiException : Exception
    {
        /// <summary>
        /// Inicializa a instância da classe <see cref="ExternoApiException"/>.
        /// </summary>
        /// <param name="erro">O erro causado pelo lançamento da excessão <see cref="string"/>.</param>
        public ExternoApiException(string erro) : base(erro)
        {
        }
    }
}

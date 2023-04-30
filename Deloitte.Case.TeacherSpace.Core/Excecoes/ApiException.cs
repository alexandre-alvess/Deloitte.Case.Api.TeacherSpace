namespace Deloitte.Case.TeacherSpace.Core.Excecoes
{
    /// <summary>
    /// Define a classe <see cref="ApiException"/>.
    /// </summary>
    public class ApiException : Exception
    {
        /// <summary>
        /// Inicializa a instância da classe <see cref="ApiException"/>.
        /// </summary>
        /// <param name="erro">O erro causado pelo lançamento da excessão <see cref="string"/>.</param>
        public ApiException(string erro) : base(erro)
        {
        }
    }
}

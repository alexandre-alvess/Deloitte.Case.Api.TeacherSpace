namespace Deloitte.Case.TeacherSpace.Domain.Utilitarios
{
    /// <summary>
    /// Define a classe <see cref="ApiParametros"/>.
    /// </summary>
    public class ApiParametros
    {
        private int _quantidade;

        /// <summary>
        /// Obtém ou define a quantidade de registros por página.
        /// </summary>
        public int Quantidade
        {
            get => _quantidade;

            set => _quantidade = value > 20 ? 20 : value < 10 ? 10 : value;
        }

        /// <summary>
        /// Obtém ou define qual é a página de pesquisa.
        /// </summary>
        public int Pagina { get; set; }
    }
}

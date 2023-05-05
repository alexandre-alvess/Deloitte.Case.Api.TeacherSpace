namespace Deloitte.Case.TeacherSpace.Domain.Utilitarios
{
    /// <summary>
    /// Define a classe <see cref="PagedResult"/>.
    /// </summary>
    public class PagedResult<TEntidade>
        where TEntidade : class
    {
        /// <summary>
        /// Obtém ou define a quantidade total de registros existentes.
        /// </summary>
        public int TotalRegistros { get; set; }

        /// <summary>
        /// Obtém ou define a quantidade total de registros que são retornados.
        /// </summary>
        public int TotalRegistrosFiltro { get; set; }

        /// <summary>
        /// Obtém ou define a lista de dados consultada.
        /// </summary>
        public IEnumerable<TEntidade> Dados { get; set; }
    }
}

﻿namespace Deloitte.Case.TeacherSpace.Services.Models
{
    /// <summary>
    /// Define a classe <see cref="UsuarioModel"/>.
    /// </summary>
    public class UsuarioModel : BaseModel
    {
        /// <summary>
        /// Obtém ou define o nome do usuário.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Obtém ou define o Login.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Obtém ou define a senha.
        /// </summary>
        public string Senha { get; set; }
    }
}

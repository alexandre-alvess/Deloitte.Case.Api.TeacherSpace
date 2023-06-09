﻿using Deloitte.Case.Api.TeacherSpace.Models.Bases;
using System.Text.Json.Serialization;

namespace Deloitte.Case.Api.TeacherSpace.Models.Responses
{
    /// <summary>
    /// Define a classe <see cref="UsuarioResponse"/>.
    /// </summary>
    public class UsuarioResponse : BaseResponse
    {
        /// <summary>
        /// Obtém ou define o nome do usuário.
        /// </summary>
        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        /// <summary>
        /// Obtém ou define o login do usuário.
        /// </summary>
        [JsonPropertyName("login")]
        public string Login { get; set; }
    }
}

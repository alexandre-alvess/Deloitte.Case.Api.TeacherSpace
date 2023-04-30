﻿using Deloitte.Case.TeacherSpace.Domain.Entidades;

namespace Deloitte.Case.TeacherSpace.Domain.Entities
{
    /// <summary>
    /// Define a classe <see cref="Professor"/>.
    /// </summary>
    public class Professor : Pessoa
    {
        /// <summary>
        /// Obtém ou define o identificador da pessoa.
        /// </summary>
        public Guid PessoaId { get; set; }

        /// <summary>
        /// Obtém ou define a pessoa.
        /// </summary>
        public virtual Pessoa Pessoa { get; set; }

        /// <summary>
        /// Obtém ou define as turmas do professor.
        /// </summary>
        public virtual ICollection<Turma> Turmas { get; set; }
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LabelModel.cs" company="TVSNext">
//   Copyright © 2021 Company="TVSNext"
// </copyright>
// <creator name="Ahamed"/>
// ----------------------------------------------------------------------------------------------------------
namespace Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fundoonotes.Models;

    /// <summary>
    /// LabelModel class
    /// </summary>
    public class LabelModel
    {
        /// <summary>
        /// Gets or sets the label identifier.
        /// </summary>
        [Key]
        public int LabelId { get; set; }

        /// <summary>
        /// Gets or sets the note identifier.
        /// </summary>
        [ForeignKey("NotesModel")]
        public int? NoteId { get; set; }

        /// <summary>
        /// Gets or sets the notes model.
        /// </summary>
        public virtual NotesModel NotesModel { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        [ForeignKey("RegisterModel")]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the register model.
        /// </summary>
        public virtual RegisterModel RegisterModel { get; set; }

        /// <summary>
        /// Gets or sets the name of the label.
        /// </summary>
        public string LabelName { get; set; }
    }
}

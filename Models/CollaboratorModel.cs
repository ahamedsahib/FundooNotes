// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorModel.cs" company="TVSNext">
//   Copyright © 2021 Company="TVSNext"
// </copyright>
// <creator name="Ahamed"/>
// ----------------------------------------------------------------------------------------------------------
namespace Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// CollaboratorModel class
    /// </summary>
    public class CollaboratorModel
    {
        /// <summary>
        /// Gets or sets the collaborator identifier.
        /// </summary>
        [Key]
        public int CollaboratorId { get; set; }

        /// <summary>
        /// Gets or sets the note identifier.
        /// </summary>
        [ForeignKey("NotesModel")]
        public int NoteId { get; set; }

        /// <summary>
        /// Gets or sets the notes model.
        /// </summary>
        public virtual NotesModel NotesModel { get; set; }

        /// <summary>
        /// Gets or sets the sender email identifier.
        /// </summary>
        public string SenderEmailId { get; set; }

        /// <summary>
        /// Gets or sets the collaborator email identifier.
        /// </summary>
        public string CollaboratorEmailId { get; set; }
    }
}

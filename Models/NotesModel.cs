// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesModel.cs" company="TVSNext">
//   Copyright © 2021 Company="TVSNext"
// </copyright>
// <creator name="Ahamed"/>
// ----------------------------------------------------------------------------------------------------------
namespace Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fundoonotes.Models;

    /// <summary>
    /// NotesModel class
    /// </summary>
    public class NotesModel
    {
        /// <summary>
        /// Gets or sets the note identifier.
        /// </summary>
        [Key]
        public int NoteId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        [Required]
        [ForeignKey("RegisterModel")]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the register model.
        /// </summary>
        public virtual RegisterModel RegisterModel { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the reminder.
        /// </summary>
        public string Reminder { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="NotesModel"/> is archive.
        /// </summary>
        [DefaultValue(false)]
        public bool Archive { get; set; }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        public string Colour { get; set; } = "white";

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="NotesModel"/> is trash.
        /// </summary>
        [DefaultValue(false)]
        public bool Trash { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="NotesModel"/> is pin.
        /// </summary>
        [DefaultValue(false)]
        public bool Pin { get; set; }
    }
}

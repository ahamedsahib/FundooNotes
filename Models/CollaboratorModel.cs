using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class CollaboratorModel
    {
        [Key]
        public int CollaboratorId { get; set; }
        [ForeignKey("NotesModel")]
        public int NoteId { get; set; }
        public virtual NotesModel NotesModel { get; set; }
        public string SenderEmailId { get; set; }
        public string CollaboratorEmailId { get; set; }
    }
}

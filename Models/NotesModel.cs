namespace Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fundoonotes.Models;
    public class NotesModel
    {
        [Key]
        public int NoteId { get; set; }

        [ForeignKey("RegisterModel")]
        public int UserId { get; set; }
        public virtual RegisterModel RegisterModel { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Reminder { get; set; }
        
        [DefaultValue(false)]
        public bool Archive { get; set; }
        public string Colour { get; set; }
        public string Image { get; set; }
        [DefaultValue(false)]
        public bool Trash { get; set; }

        [DefaultValue(false)]
        public bool Pin { get; set; }

    }
}

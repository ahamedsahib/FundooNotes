using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Interface
{
    public interface INotesManager
    {
        string AddNote(NotesModel noteData);
        string DeleteNote(int noteId);
        string ChangeNoteColor(int noteId, string noteColor);
        bool ChangePin(int noteId);
    }
}

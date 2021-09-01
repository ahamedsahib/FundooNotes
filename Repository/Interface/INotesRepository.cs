using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface INotesRepository
    {
        string AddNote(NotesModel noteData);
        string DeleteNote(int noteId);
    }
}

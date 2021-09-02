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
        string ChangeNoteColor(int noteId, string noteColor);
        bool ChangePin(int noteId);
        bool Archive(int noteId);
        bool MoveToTrash(int noteId);
        bool RestoreNote(int noteId);
        List<NotesModel> GetNote(int userId);
        bool UpdateNote(NotesModel noteData);
        bool SetReminder(int noteId, string addReminder);
        bool UnsetReminder(int noteId);
        List<NotesModel> GetReminder(int userId);
        List<NotesModel> GetArchive(int userId);
        List<NotesModel> GetTrash(int userId);
        bool EmptyTrash(int userId);
    }
}

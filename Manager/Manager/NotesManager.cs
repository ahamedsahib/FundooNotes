using Manager.Interface;
using Models;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Manager
{
     public class NotesManager:INotesManager
    {
        private readonly INotesRepository repository;

        public NotesManager(INotesRepository repository)
        {
            this.repository = repository;
        }

        public string AddNote(NotesModel noteData)
        {
            try
            {
                return this.repository.AddNote(noteData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string DeleteNote(int noteId)
        {
            try
            {
                return this.repository.DeleteNote(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string ChangeNoteColor(int noteId, string noteColor)
        {
            try
            {
                return this.repository.ChangeNoteColor(noteId,noteColor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool ChangePin(int noteId)
        {
            try
            {
                return this.repository.ChangePin(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool Archive(int noteId)
        {
            try
            {
                return this.repository.Archive(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

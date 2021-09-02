namespace Repository.Repository
{
    using System;
    using Models;
    using global::Repository.Context;
    using global::Repository.Interface;
    using System.Collections.Generic;
    using System.Linq;

    public class NotesRepository : INotesRepository
    {
        private readonly UserContext userContext;

        public NotesRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        public string AddNote(NotesModel noteData)
        {
            try
            {
                if (noteData.Title != null || noteData.Description != null)
                {
                    this.userContext.Notes.Add(noteData);
                    this.userContext.SaveChanges();
                    return "Notes Addedd Successfully";
                }
                return "Unsuccessfull";

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
                var checkNote = this.userContext.Notes.Find(noteId);
                if (checkNote != null && checkNote.Trash == true)
                {
                    this.userContext.Notes.Remove(checkNote);
                    this.userContext.SaveChanges();
                    return "Note Deleted";
                }

                return "Note not Found";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool MoveToTrash(int noteId)
        {
            try
            {
                var checkNote = this.userContext.Notes.Find(noteId);
                if (checkNote != null)
                {
                    checkNote.Trash = true;
                    this.userContext.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool RestoreNote(int noteId)
        {
            try
            {
                var checkNote = this.userContext.Notes.Find(noteId);
                if (checkNote != null)
                {
                    checkNote.Trash = false;
                    this.userContext.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string ChangeNoteColor(int noteId, string notecolor)
        {
            try
            {
                var checkNote = this.userContext.Notes.Find(noteId);
                if (checkNote != null)
                {
                    checkNote.Colour = notecolor;
                    this.userContext.SaveChanges();
                    return "Colour Updated";
                }

                    return "Error!! Colour not updated ";
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
                var checkNote = this.userContext.Notes.Find(noteId);
                if (checkNote != null)
                {
                    checkNote.Pin = checkNote.Pin ? false : true;
                    this.userContext.SaveChanges();
                    return true;
                }
                return false;
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
                var checkNote = this.userContext.Notes.Find(noteId);
                if (checkNote != null)
                {
                    checkNote.Archive = checkNote.Archive ? false : true;
                    this.userContext.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<NotesModel> GetNote(int userId)
        {
            var notes = this.userContext.Notes.Where(x => x.UserId == userId && x.Archive == false && x.Trash == false).ToList();
            try
            {
                if (notes != null)
                {
                    return notes;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateNote(NotesModel noteData)
        {
            try
            {
                var checkNote = this.userContext.Notes.Find(noteData.NoteId);
                
                if (checkNote != null)
                {
                    checkNote.Title = noteData.Title;
                    checkNote.Description = noteData.Description;
                    this.userContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool SetReminder(int noteId,string addReminder)
        {
            try
            {
                var checkNote = this.userContext.Notes.Find(noteId);
                if (checkNote != null)
                {
                    checkNote.Reminder = addReminder;
                    this.userContext.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

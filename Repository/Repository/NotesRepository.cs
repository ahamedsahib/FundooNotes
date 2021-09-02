namespace Repository.Repository
{
    using System;
    using Models;
    using global::Repository.Context;
    using global::Repository.Interface;
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
                if (noteData.Title != null && noteData.Description != null)
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
                var checkId = this.userContext.Notes.Find(noteId);
                if (checkId != null)
                {
                    checkId.Trash = true;
                    this.userContext.SaveChanges();
                    return "Note Moved to Trash";
                }

                return "Note not Found";
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
    }
}

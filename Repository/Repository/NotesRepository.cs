using Models;
using Repository.Context;
using Repository.Interface;
using System;
namespace Repository.Repository
{
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
                    this.userContext.Notes.Remove(checkId);
                    this.userContext.SaveChanges();
                    return "Note Deleted Successfully";
                }

                return "Note not Present";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

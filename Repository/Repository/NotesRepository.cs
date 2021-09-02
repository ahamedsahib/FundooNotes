// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesRepository.cs" company="TVSNext">
//   Copyright © 2021 Company="TVSNext"
// </copyright>
// <creator name="Ahamed"/>
// ----------------------------------------------------------------------------------------------------------
namespace Repository.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
        public bool UnsetReminder(int noteId)
        {
            try
            {
                var checkNote = this.userContext.Notes.Find(noteId);
                if (checkNote != null)
                {
                    checkNote.Reminder = null;
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
        public List<NotesModel> GetReminder(int userId)
        {
            var notes = this.userContext.Notes.Where(x => x.UserId == userId && x.Reminder!=null && x.Trash==false).ToList();
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
        public List<NotesModel> GetArchive(int userId)
        {
            var notes = this.userContext.Notes.Where(x => x.UserId == userId && x.Archive == true && x.Trash == false).ToList();
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
        public List<NotesModel> GetTrash(int userId)
        {
            var notes = this.userContext.Notes.Where(x => x.UserId == userId && x.Trash == true).ToList();
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
        public bool EmptyTrash(int userId)
        {
            try
            {
                var notes = this.userContext.Notes.Where(x => x.UserId == userId && x.Trash == true).ToList();
                if (notes != null)
                {
                    this.userContext.Notes.RemoveRange(notes);
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

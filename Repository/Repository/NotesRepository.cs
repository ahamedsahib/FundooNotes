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
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Models;
    using global::Repository.Context;
    using global::Repository.Interface;

    /// <summary>
    /// NotesRepository class
    /// </summary>
    /// <seealso cref="Repository.Interface.INotesRepository" />
    public class NotesRepository : INotesRepository
    {
        /// <summary>
        /// The user context
        /// </summary>
        private readonly UserContext userContext;

        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesRepository"/> class.
        /// </summary>
        /// <param name="userContext">The user context.</param>
        /// <param name="configuration">The configuration.</param>
        public NotesRepository(UserContext userContext, IConfiguration configuration)
        {
            this.userContext = userContext;
            this.configuration = configuration;
        }

        /// <summary>
        /// Adds the note.
        /// </summary>
        /// <param name="noteData">The note data.</param>
        /// <returns>
        /// success if note added
        /// </returns>
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

        /// <summary>
        /// Deletes the note.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>
        /// success if note deleted
        /// </returns>
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

        /// <summary>
        /// Moves to trash.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>
        /// true if item moved to trash
        /// </returns>
        public bool MoveToTrash(int noteId)
        {
            try
            {
                var checkNote = this.userContext.Notes.Find(noteId);
                if (checkNote != null)
                {
                    checkNote.Trash = true;
                    checkNote.Reminder = null;
                    checkNote.Pin = false;
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

        /// <summary>
        /// Restores the note.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>
        /// restore note from trash
        /// </returns>
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

        /// <summary>
        /// Changes the color of the note.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <param name="notecolor">The note color.</param>
        /// <returns>true if note color changed</returns>
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

        /// <summary>
        /// Changes the pin.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>
        /// &gt;true if we Change Pin
        /// </returns>
        public bool ChangePin(int noteId)
        {
            try
            {
                var checkNote = this.userContext.Notes.Find(noteId);
                if (checkNote != null)
                {
                    checkNote.Pin = checkNote.Pin ? false : true;
                    checkNote.Archive = false;
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

        /// <summary>
        /// Archives the specified note identifier.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>
        /// true if item moved to Archive
        /// </returns>
        public bool Archive(int noteId)
        {
            try
            {
                var checkNote = this.userContext.Notes.Find(noteId);
                if (checkNote != null)
                {
                    checkNote.Archive = checkNote.Archive ? false : true;
                    checkNote.Pin = false;
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

        /// <summary>
        /// Gets the note.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// get all note in note
        /// </returns>
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

        /// <summary>
        /// Updates the note.
        /// </summary>
        /// <param name="noteData">The note data.</param>
        /// <returns>
        /// updated note
        /// </returns>
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

        /// <summary>
        /// Sets the reminder.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <param name="addReminder">The add reminder.</param>
        /// <returns>
        /// add reminder
        /// </returns>
        public bool SetReminder(int noteId, string addReminder)
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

        /// <summary>
        /// Unsets the reminder.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>
        /// Unset reminder
        /// </returns>
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

        /// <summary>
        /// Gets the reminder.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// Notes in Reminder
        /// </returns>
        public List<NotesModel> GetReminder(int userId)
        {
            var notes = this.userContext.Notes.Where(x => x.UserId == userId && x.Reminder != null && x.Trash == false).ToList();
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

        /// <summary>
        /// Gets the archive.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// Note in Archive
        /// </returns>
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

        /// <summary>
        /// Gets the trash.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// notes in trash
        /// </returns>
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

        /// <summary>
        /// Empties the trash.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// Trash empty or not
        /// </returns>
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

        /// <summary>
        /// Adds the image.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <param name="imagePath">The image path.</param>
        /// <returns>
        /// true if image added
        /// </returns>
        public bool AddImage(int noteId, IFormFile imagePath)
        {
            try
            {
                var note = this.userContext.Notes.Where(x => x.NoteId == noteId && x.Trash == false).SingleOrDefault();
                if (note != null)
                {
                    Account account = new Account(this.configuration.GetSection("CloudinaryAccount").GetSection("CloudName").Value, this.configuration.GetSection("CloudinaryAccount").GetSection("ApiKey").Value, this.configuration.GetSection("CloudinaryAccount").GetSection("ApiSecret").Value);
                    Cloudinary cloudinary = new Cloudinary(account);

                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(imagePath.FileName, imagePath.OpenReadStream())
                    };
                    var uploadResult = cloudinary.Upload(uploadParams);
                    Uri x = uploadResult.Url;
                    note.Image = x.ToString();
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

        /// <summary>
        /// Deletes the image.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>
        /// true if image deleted
        /// </returns>
        public bool DeleteImage(int noteId)
        {
            try
            {
                var checkNote = this.userContext.Notes.Find(noteId);
                if (checkNote != null)
                {
                    checkNote.Image = null;
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

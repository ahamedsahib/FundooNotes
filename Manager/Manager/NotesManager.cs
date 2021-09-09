// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesManager.cs" company="TVSNext">
//   Copyright © 2021 Company="TVSNext"
// </copyright>
// <creator name="Ahamed"/>
// ----------------------------------------------------------------------------------------------------------
namespace Manager.Manager
{
    using System;
    using System.Collections.Generic;
    using global::Manager.Interface;
    using Microsoft.AspNetCore.Http;
    using Models;
    using Repository.Interface;

    /// <summary>
    /// NotesManager class
    /// </summary>
    /// <seealso cref="Manager.Interface.INotesManager" />
    public class NotesManager : INotesManager
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly INotesRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesManager"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public NotesManager(INotesRepository repository)
        {
            this.repository = repository;
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
                return this.repository.AddNote(noteData);
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
                return this.repository.DeleteNote(noteId);
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
        /// <param name="noteColor">Color of the note.</param>
        /// <returns>
        /// color updated
        /// </returns>
        public string ChangeNoteColor(int noteId, string noteColor)
        {
            try
            {
                return this.repository.ChangeNoteColor(noteId, noteColor);
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
                return this.repository.ChangePin(noteId);
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
        /// &gt;true if item moved to Archive
        /// </returns>
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
                return this.repository.MoveToTrash(noteId);
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
                return this.repository.MoveToTrash(noteId);
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
            try
            {
                return this.repository.GetNote(userId);
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
                return this.repository.UpdateNote(noteData);
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
               return this.repository.SetReminder(noteId, addReminder);
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
                return this.repository.UnsetReminder(noteId);
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
            try
            {
                return this.repository.GetReminder(userId);
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
            try
            {
                return this.repository.GetArchive(userId);
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
            try
            {
                return this.repository.GetTrash(userId);
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
                return this.repository.EmptyTrash(userId);
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
                return this.repository.AddImage(noteId, imagePath);
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
                return this.repository.DeleteImage(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

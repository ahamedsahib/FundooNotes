// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INotesRepository.cs" company="TVSNext">
//   Copyright © 2021 Company="TVSNext"
// </copyright>
// <creator name="Ahamed"/>
// ----------------------------------------------------------------------------------------------------------
namespace Repository.Interface
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Http;
    using Models;

    /// <summary>
    /// INotesRepository interface
    /// </summary>
    public interface INotesRepository
    {
        /// <summary>
        /// Adds the note.
        /// </summary>
        /// <param name="noteData">The note data.</param>
        /// <returns>success if note added</returns>
        string AddNote(NotesModel noteData);

        /// <summary>
        /// Deletes the note.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>success if note deleted</returns>
        string DeleteNote(int noteId);

        /// <summary>
        /// Changes the color of the note.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <param name="noteColor">Color of the note.</param>
        /// <returns>color updated</returns>
        string ChangeNoteColor(int noteId, string noteColor);

        /// <summary>
        /// Changes the pin.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>>true if we Change Pin</returns>
        bool ChangePin(int noteId);

        /// <summary>
        /// Archives the specified note identifier.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>>true if item moved to Archive</returns>
        bool Archive(int noteId);

        /// <summary>
        /// Moves to trash.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>true if item moved to trash</returns>
        bool MoveToTrash(int noteId);

        /// <summary>
        /// Restores the note.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>restore note from trash</returns>
        bool RestoreNote(int noteId);

        /// <summary>
        /// Gets the note.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>get all note in note</returns>
        List<NotesModel> GetNote(int userId);

        /// <summary>
        /// Updates the note.
        /// </summary>
        /// <param name="noteData">The note data.</param>
        /// <returns>updated note</returns>
        bool UpdateNote(NotesModel noteData);

        /// <summary>
        /// Sets the reminder.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <param name="addReminder">The add reminder.</param>
        /// <returns>add reminder</returns>
        bool SetReminder(int noteId, string addReminder);

        /// <summary>
        /// Unsets the reminder.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>Unset reminder</returns>
        bool UnsetReminder(int noteId);

        /// <summary>
        /// Gets the reminder.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Notes in Reminder </returns>
        List<NotesModel> GetReminder(int userId);

        /// <summary>
        /// Gets the archive.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Note in Archive</returns>
        List<NotesModel> GetArchive(int userId);

        /// <summary>
        /// Gets the trash.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>notes in trash</returns>
        List<NotesModel> GetTrash(int userId);

        /// <summary>
        /// Empties the trash.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Trash empty or not</returns>
        bool EmptyTrash(int userId);

        /// <summary>
        /// Adds the image.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <param name="imagePath">The image path.</param>
        /// <returns>true if image added </returns>
        bool AddImage(int noteId, IFormFile imagePath);

        /// <summary>
        /// Deletes the image.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>true if image deleted</returns>
        bool DeleteImage(int noteId);
    }
}

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILabelRepository.cs" company="TVSNext">
//   Copyright © 2021 Company="TVSNext"
// </copyright>
// <creator name="Ahamed"/>
// ----------------------------------------------------------------------------------------------------------
namespace Repository.Interface
{
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// ILabelRepository interface
    /// </summary>
    public interface ILabelRepository
    {
        /// <summary>
        /// Adds the label to note.
        /// </summary>
        /// <param name="labelData">The label data.</param>
        /// <returns>return string success or not</returns>
        string AddLabelToNote(LabelModel labelData);

        /// <summary>
        /// Adds the label to user.
        /// </summary>
        /// <param name="labelData">The label data.</param>
        /// <returns>return string success or not</returns>
        string AddLabelToUser(LabelModel labelData);

        /// <summary>
        /// Deletes the label on note.
        /// </summary>
        /// <param name="labelId">The label identifier.</param>
        /// <returns>return true if success</returns>
        bool DeleteLabelOnNote(int labelId);

        /// <summary>
        /// Deletes the label.
        /// </summary>
        /// <param name="labelData">The label data.</param>
        /// <returns>true if label deleted</returns>
        bool DeleteLabel(LabelModel labelData);

        /// <summary>
        /// Edits the name of the label.
        /// </summary>
        /// <param name="labelData">The label data.</param>
        /// <returns>true if label updated</returns>
        bool EditLabelName(LabelModel labelData);

        /// <summary>
        /// Gets the labels.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>all Labels</returns>
        List<string> GetLabels(int userId);

        /// <summary>
        /// Gets the labels notes.
        /// </summary>
        /// <param name="labelData">The label data.</param>
        /// <returns>all notes of label</returns>
        List<NotesModel> GetLabelsNotes(LabelModel labelData);

        /// <summary>
        /// Gets the notes label.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>list of Labels of note</returns>
        List<LabelModel> GetNotesLabel(int noteId);
    }
}

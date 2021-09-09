// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILabelManager.cs" company="TVSNext">
//   Copyright © 2021 Company="TVSNext"
// </copyright>
// <creator name="Ahamed"/>
// ----------------------------------------------------------------------------------------------------------
namespace Manager.Interface
{
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// ILabelManager interface
    /// </summary>
    public interface ILabelManager
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
        /// <param name="userId">The user identifier.</param>
        /// <param name="labelName">Name of the label.</param>
        /// <returns>return true if success</returns>
        bool DeleteLabel(int userId, string labelName);

        /// <summary>
        /// Edits the name of the label.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="existinglabelName">Name of the existing label.</param>
        /// <param name="newLabelName">New name of the label.</param>
        /// <returns>return true if success</returns>
        bool EditLabelName(int userId, string existinglabelName, string newLabelName);

        /// <summary>
        /// Gets the labels.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>all Labels</returns>
        List<string> GetLabels(int userId);

        /// <summary>
        /// Gets the labels notes.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="labelName">Name of the label.</param>
        /// <returns>all notes of labels</returns>
        List<NotesModel> GetLabelsNotes(int userId, string labelName);
    }
}

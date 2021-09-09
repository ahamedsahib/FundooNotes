// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LabelManager.cs" company="TVSNext">
//   Copyright © 2021 Company="TVSNext"
// </copyright>
// <creator name="Ahamed"/>
// ----------------------------------------------------------------------------------------------------------
namespace Manager.Manager
{
    using System;
    using System.Collections.Generic;
    using global::Manager.Interface;
    using Models;
    using Repository.Interface;
 
    /// <summary>
    /// LabelManager class
    /// </summary>
    /// <seealso cref="ILabelManager" />
    public class LabelManager : ILabelManager
    {
        /// <summary>
        /// The repository/
        /// </summary>
        private readonly ILabelRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelManager"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public LabelManager(ILabelRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Adds the label to note.
        /// </summary>
        /// <param name="labelData">The label data.</param>
        /// <returns>
        /// return string success or not
        /// </returns>
        public string AddLabelToNote(LabelModel labelData)
        {
            try
            {
                return this.repository.AddLabelToNote(labelData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Adds the label to user.
        /// </summary>
        /// <param name="labelData">The label data.</param>
        /// <returns>
        /// return string success or not
        /// </returns>
        public string AddLabelToUser(LabelModel labelData)
        {
            try
            {
                return this.repository.AddLabelToUser(labelData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Deletes the label on note.
        /// </summary>
        /// <param name="labelId">The label identifier.</param>
        /// <returns>
        /// return true if success
        /// </returns>
        public bool DeleteLabelOnNote(int labelId)
        {
            try
            {
                return this.repository.DeleteLabelOnNote(labelId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Deletes the label.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="labelName">Name of the label.</param>
        /// <returns>
        /// return true if success
        /// </returns>
        public bool DeleteLabel(int userId, string labelName)
        {
            try
            {
                return this.repository.DeleteLabel(userId, labelName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edits the name of the label.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="existinglabelName">Name of the existing label.</param>
        /// <param name="newLabelName">New name of the label.</param>
        /// <returns>
        /// return true if success
        /// </returns>
        public bool EditLabelName(int userId, string existinglabelName, string newLabelName)
        {
            try
            {
                return this.repository.EditLabelName(userId, existinglabelName, newLabelName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets the labels.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// all Labels
        /// </returns>
        public List<string> GetLabels(int userId)
        {
            try
            {
                return this.repository.GetLabels(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets the labels notes.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="labelName">Name of the label.</param>
        /// <returns>
        /// all notes of labels
        /// </returns>
        public List<NotesModel> GetLabelsNotes(int userId, string labelName)
        {
            try
            {
                return this.repository.GetLabelsNotes(userId, labelName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

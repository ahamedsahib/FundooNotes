// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LabelRepository.cs" company="TVSNext">
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

    /// <summary>
    /// LabelRepository class
    /// </summary>
    public class LabelRepository : ILabelRepository
    {
        /// <summary>
        /// user Context
        /// </summary>
        private readonly UserContext userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelRepository"/> class.
        /// </summary>
        /// <param name="userContext">userContext identifier</param>
        public LabelRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        /// <summary>
        /// Adds the label to note.
        /// </summary>
        /// <param name="labelData">The label data.</param>
        /// <returns>return string success or not</returns>
        public string AddLabelToNote(LabelModel labelData)
        {
            try
            {
                var checkLabel = (from l in this.userContext.Labels
                                    where (l.LabelName.Equals(labelData.LabelName) && labelData.UserId == l.UserId && l.NoteId == labelData.NoteId)
                                    select l).FirstOrDefault();
                if (checkLabel == null)
                {
                    this.userContext.Labels.Add(labelData);
                    this.userContext.SaveChanges();
                    var checkLabel1 = this.userContext.Labels.Where(x => x.UserId == labelData.UserId && x.LabelName.Equals(labelData.LabelName) && x.NoteId == null).FirstOrDefault();
                    if (checkLabel1 == null)
                    {
                        labelData.LabelId = 0;
                        labelData.NoteId = null;
                        this.userContext.Labels.Add(labelData);
                        this.userContext.SaveChanges();
                    }

                    return "Label Added Successfully";
                }

                return "label added failed";
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
        /// <returns>return string success or not</returns>
        public string AddLabelToUser(LabelModel labelData)
        {
            try
            {
                var checkLabel1 = this.userContext.Labels.Where(x => x.UserId == labelData.UserId && x.LabelName.Equals(labelData.LabelName)).FirstOrDefault();
                if (checkLabel1 == null)
                {
                    this.userContext.Labels.Add(labelData);
                    this.userContext.SaveChanges();
                    return "Label Added Successfully";
                }

                return "label added failed";
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
        /// <returns>return true if success</returns>
        public bool DeleteLabel(int userId, string labelName)
        {
            try
            {
                var checkLabel = this.userContext.Labels.Where(x => x.UserId == userId && x.LabelName.Equals(labelName)).ToList();
                if (checkLabel != null)
                {
                    this.userContext.Labels.RemoveRange(checkLabel);
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
        /// Deletes the label on note.
        /// </summary>
        /// <param name="labelId">The label identifier.</param>
        /// <returns>return true if success</returns>
        public bool DeleteLabelOnNote(int labelId)
        {
            try
            {
                var checkLabel = this.userContext.Labels.Find(labelId);
                if (checkLabel != null)
                {
                    this.userContext.Labels.Remove(checkLabel);
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
        /// Edits the name of the label.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="existinglabelName">Name of the existing label.</param>
        /// <param name="newLabelName">New name of the label.</param>
        /// <returns>return true if success</returns>
        public bool EditLabelName(int userId, string existinglabelName, string newLabelName)
        {
            try
            {
                var checkLabel = this.userContext.Labels.Where(x => x.UserId == userId && x.LabelName.Equals(existinglabelName)).ToList();
                if (checkLabel != null)
                {
                    checkLabel.ForEach(a => a.LabelName = newLabelName);
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
        /// Gets the labels.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>all Labels</returns>
        public List<string> GetLabels(int userId)
        {
            try
            {
                var labels = this.userContext.Labels.Where(x => x.UserId == userId).Select(i => i.LabelName).Distinct().ToList();
                if (labels.Count > 0)
                {
                    return labels;
                }

                return null;
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
        /// <returns>all notes of labels</returns>
        public List<NotesModel> GetLabelsNotes(int userId, string labelName)
        {
            try
            {
                var labels = (from l in this.userContext.Labels
                             join n in this.userContext.Notes on l.NoteId equals n.NoteId
                             where (l.UserId == userId && l.LabelName.Equals(labelName) && n.Trash == false)
                             select n).ToList();
                if (labels != null)
                {
                    return labels;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

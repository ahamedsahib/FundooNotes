using Models;
using Repository.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repository
{
    public class LabelRepository: ILabelRepository
    {
        private readonly UserContext userContext;

        public LabelRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        public string AddLabelToNote(LabelModel labelData)
        {
            try
            {
                var checkLabel = (from l in this.userContext.Labels
                                  join n in this.userContext.Notes on labelData.NoteId equals n.NoteId
                                  where (l.LabelName.Equals(labelData.LabelName) && l.UserId == labelData.UserId ||  n.Trash == true)
                                  select n );
                if (checkLabel == null)
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
        public string AddLabelToUser(LabelModel labelData)
        {
            try
            {
                var checkLabel = this.userContext.Labels.Where(x => x.UserId == labelData.UserId && x.LabelName.Equals(labelData.LabelName)).FirstOrDefault();
                if (checkLabel == null)
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
        public bool EditLabelName(int userId, string existinglabelName, string newLabelName)
        {
            try
            {
                var checkLabel= this.userContext.Labels.Where(x => x.UserId == userId && x.LabelName.Equals(existinglabelName)).ToList();
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
        public List<NotesModel> GetLabelsNotes(int userId, string labelName)
        {
            try
            {
                var labels = (from l in this.userContext.Labels
                             join n in this.userContext.Notes on l.NoteId equals n.NoteId
                             where (l.UserId == userId && l.LabelName.Equals(labelName)&& n.Trash == false)
                             select n).ToList();
                if(labels != null)
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

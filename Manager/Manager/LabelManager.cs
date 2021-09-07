using Manager.Interface;
using Models;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Manager
{
    public class LabelManager: ILabelManager
    {
        private readonly ILabelRepository repository;

        
        public LabelManager(ILabelRepository repository)
        {
            this.repository = repository;
        }

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

        public bool DeleteLabelOnNote(int LabelId)
        {
            try
            {
                return this.repository.DeleteLabelOnNote(LabelId);
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
                return this.repository.DeleteLabel(userId, labelName);
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
                return this.repository.EditLabelName(userId, existinglabelName, newLabelName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

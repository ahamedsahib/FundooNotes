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
    }
}

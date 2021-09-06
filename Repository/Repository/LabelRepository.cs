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
                var checkLabel = this.userContext.Labels.Where(x => x.NoteId == labelData.NoteId && x.LabelName.Equals(labelData.LabelName)).SingleOrDefault();
                if (labelData != null)
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
    }
}

using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface ILabelRepository
    {
        string AddLabelToNote(LabelModel labelData);
        string AddLabelToUser(LabelModel labelData);
        bool DeleteLabelOnNote(int LabelId);
        bool DeleteLabel(int userId, string labelName);
        bool EditLabelName(int userId, string existinglabelName, string newLabelName);
    }
}

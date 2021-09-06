using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Interface
{
    public interface ILabelManager
    {
        string AddLabelToNote(LabelModel labelData);
        string AddLabelToUser(LabelModel labelData);
        bool DeleteLabelOnNote(int noteId, int LabelId);
    }
}

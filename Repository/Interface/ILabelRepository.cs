using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface ILabelRepository
    {
        string AddLabelToNote(LabelModel labelData);
    }
}

using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface ICollaboratorRepository
    {
        string AddCollaborator(CollaboratorModel collaboratorData);
        string DeleteCollaborator(int noteId, int collaboratorId);
    }
}

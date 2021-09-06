using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Interface
{
    public interface ICollaboratorManager
    {
        string AddCollaborator(CollaboratorModel collaboratorData);
        string DeleteCollaborator(int noteId, int collaboratorId);
        List<CollaboratorModel> GetCollaborator(int noteId);
    }
}

using Manager.Interface;
using Models;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Manager
{
    public class CollaboratorManager : ICollaboratorManager
    {
        private readonly ICollaboratorRepository repository;

        public CollaboratorManager(ICollaboratorRepository repository)
        {
            this.repository = repository;
        }
        public string AddCollaborator(CollaboratorModel collaboratorData)
        {
            try
            {
                return this.repository.AddCollaborator(collaboratorData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

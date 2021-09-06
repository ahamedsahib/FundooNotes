using Models;
using Repository.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repository
{
    public class CollaboratorRepository: ICollaboratorRepository
    {
        private readonly UserContext userContext;

        public CollaboratorRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        public string AddCollaborator(CollaboratorModel collaboratorData)
        {
            try
            {
                if (collaboratorData.SenderEmailId != collaboratorData.CollaboratorEmailId)
                { 
                    var checkEmailIdExists = this.userContext.Collaborator.Where(x => x.CollaboratorEmailId.Equals(collaboratorData.CollaboratorEmailId) && x.NoteId == collaboratorData.NoteId).FirstOrDefault();
                    
                    if (checkEmailIdExists == null)
                    {

                        this.userContext.Collaborator.Add(collaboratorData);
                        this.userContext.SaveChanges();
                        return "Collaborator Added Successfully";
                    }

                    return "Email Id Already Exists";
                }

                return "Invalid!! Can't add owner email id";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string DeleteCollaborator(int noteId, int collaboratorId)
        {
            try
            {
                var checkCollaborator = this.userContext.Collaborator.Where(x => x.CollaboratorId.Equals(collaboratorId) && x.NoteId == noteId).SingleOrDefault();

                if (checkCollaborator != null)
                {

                    this.userContext.Collaborator.Remove(checkCollaborator);
                    this.userContext.SaveChanges();
                    return "Collaborator Deleted Successfully";
                }

                return "Collaborator Email Id not found";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<CollaboratorModel> GetCollaborator(int noteId)
        {
            try
            {
                var getCollaborator = this.userContext.Collaborator.Where(x => x.NoteId == noteId).ToList();

                if (getCollaborator != null)
                {
                    return getCollaborator;
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

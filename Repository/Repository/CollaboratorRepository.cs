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
                var checkEmail = this.userContext.Users.Where(x => x.Email.Equals(collaboratorData.CollaboratorEmailId)).FirstOrDefault();
                var checkNote = this.userContext.Notes.Where(x => x.NoteId == collaboratorData.NoteId).FirstOrDefault();
                //var result = from s in this.userContext.Users
                //             join sa in this.userContext.Notes on s.UserId equals sa.UserId
                //             where s.
                if (collaboratorData != null)
                {
                    if (checkNote != null)
                    {
                        if (checkEmail != null)
                        {

                            this.userContext.Collaborator.Add(collaboratorData);
                            this.userContext.SaveChanges();
                            return "Collaborator Added Successfully";
                        }
                        return "Email id not registered";
                    }
                    return "Note not Found";
                }
                return "Collaborator Addedd Failed";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

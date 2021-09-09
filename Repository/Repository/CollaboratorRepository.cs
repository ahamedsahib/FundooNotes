// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorRepository.cs" company="TVSNext">
//   Copyright © 2021 Company="TVSNext"
// </copyright>
// <creator name="Ahamed"/>
// ----------------------------------------------------------------------------------------------------------
namespace Repository.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using global::Repository.Context;
    using global::Repository.Interface;

    /// <summary>
    /// CollaboratorRepository class
    /// </summary>
    /// <seealso cref="Repository.Interface.ICollaboratorRepository" />
    public class CollaboratorRepository : ICollaboratorRepository
    {
        /// <summary>
        /// The user context
        /// </summary>
        private readonly UserContext userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollaboratorRepository"/> class.
        /// </summary>
        /// <param name="userContext">The user context.</param>
        public CollaboratorRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        /// <summary>
        /// Adds the collaborator.
        /// </summary>
        /// <param name="collaboratorData">The collaborator data.</param>
        /// <returns>
        /// return string success or not
        /// </returns>
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

        /// <summary>
        /// Deletes the collaborator.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <param name="collaboratorId">The collaborator identifier.</param>
        /// <returns>
        /// return string success or not
        /// </returns>
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

        /// <summary>
        /// Gets the collaborator.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>
        /// list of all Collaborator
        /// </returns>
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

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorManager.cs" company="TVSNext">
//   Copyright © 2021 Company="TVSNext"
// </copyright>
// <creator name="Ahamed"/>
// ----------------------------------------------------------------------------------------------------------
namespace Manager.Manager
{
    using System;
    using System.Collections.Generic;
    using global::Manager.Interface;
    using Models;
    using Repository.Interface;

    /// <summary>
    /// CollaboratorManager class
    /// </summary>
    /// <seealso cref="Manager.Interface.ICollaboratorManager" />
    public class CollaboratorManager : ICollaboratorManager
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly ICollaboratorRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollaboratorManager"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public CollaboratorManager(ICollaboratorRepository repository)
        {
            this.repository = repository;
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
                return this.repository.AddCollaborator(collaboratorData);
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
                return this.repository.DeleteCollaborator(noteId, collaboratorId);
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
                return this.repository.GetCollaborator(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

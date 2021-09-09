﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICollaboratorManager.cs" company="TVSNext">
//   Copyright © 2021 Company="TVSNext"
// </copyright>
// <creator name="Ahamed"/>
// ----------------------------------------------------------------------------------------------------------
namespace Manager.Interface
{
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// ICollaboratorManager interface
    /// </summary>
    public interface ICollaboratorManager
    {
        /// <summary>
        /// Adds the collaborator.
        /// </summary>
        /// <param name="collaboratorData">The collaborator data.</param>
        /// <returns>return string success or not</returns>
        string AddCollaborator(CollaboratorModel collaboratorData);

        /// <summary>
        /// Deletes the collaborator.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <param name="collaboratorId">The collaborator identifier.</param>
        /// <returns>return string success or not</returns>
        string DeleteCollaborator(int noteId, int collaboratorId);

        /// <summary>
        /// Gets the collaborator.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>list of all Collaborator</returns>
        List<CollaboratorModel> GetCollaborator(int noteId);
    }
}

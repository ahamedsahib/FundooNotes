// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorController.cs" company="TVSNext">
//   Copyright © 2021 Company="TVSNext"
// </copyright>
// <creator name="Ahamed"/>
// ----------------------------------------------------------------------------------------------------------
namespace Fundoonotes.Controller.Controller
{
    using System;
    using System.Collections.Generic;
    using global::Manager.Manager;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using global::Models;

    /// <summary>
    /// CollaboratorController class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Authorize]
    public class CollaboratorController : ControllerBase
    {
        /// <summary>
        /// The manager
        /// </summary>
        private readonly CollaboratorManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollaboratorController"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public CollaboratorController(CollaboratorManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Adds the note.
        /// </summary>
        /// <param name="collaboratorData">The collaborator data.</param>
        /// <returns>collaborator Added Successfully or not</returns>
        [HttpPost]
        [Route("api/addCollaborator")]
        public IActionResult AddNote([FromBody] CollaboratorModel collaboratorData)
        {
            try
            {
                string result = this.manager.AddCollaborator(collaboratorData);
                if (result.Equals("collaborator Added Successfully"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Deletes the collaborator.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <param name="collaboratorId">The collaborator identifier.</param>
        /// <returns>collaborator deleted Successfully</returns>
        [HttpDelete]
        [Route("api/deleteCollaborator")]
        public IActionResult DeleteCollaborator(int noteId, int collaboratorId)
        {
            try
            {
                string result = this.manager.DeleteCollaborator(noteId, collaboratorId);
                if (result.Equals("Collaborator Deleted Successfully"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                
                return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });    
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Gets the collaborator.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>all Collaborator of note</returns>
        [HttpGet]
        [Route("api/getCollaborator")]
        public IActionResult GetCollaborator(int noteId)
        {
            try
            {
                var result = this.manager.GetCollaborator(noteId);
                if (result.Count > 0)
                {
                    return this.Ok(new ResponseModel<List<CollaboratorModel>>() { Status = true, Message = "All Notes are Succesfully Fetched", Data = result });
                }
             
                return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Error!!No Note Found on Archive" });    
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}

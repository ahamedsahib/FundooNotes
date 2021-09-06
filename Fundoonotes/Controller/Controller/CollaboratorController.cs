using Manager.Manager;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fundoonotes.Controller.Controller
{
    public class CollaboratorController : ControllerBase
    {
        private readonly CollaboratorManager manager;

        public CollaboratorController(CollaboratorManager manager)
        {
            this.manager = manager;
        }

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
    }
}

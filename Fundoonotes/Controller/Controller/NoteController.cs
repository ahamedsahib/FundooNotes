using Manager.Interface;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;

namespace Fundoonotes.Controller.Controller
{
    public class NoteController : ControllerBase
    {
        private readonly INotesManager manager;

        public NoteController(INotesManager manager)
        {
            this.manager = manager;
        }

        [HttpPost]
        [Route("api/addnotes")]
        public IActionResult AddNote([FromBody] NotesModel noteData)
        {
            try
            {
                string result = this.manager.AddNote(noteData);
                if (result.Equals("Notes Addedd Successfully"))
                {
                    return this.Ok(new ResponseModel<string>() { status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { status = false, Message = ex.Message });
            }
        }
        [HttpDelete]
        [Route("api/deletenotes")]
        public IActionResult DeleteNote(int noteId)
        {
            try
            {
                string result = this.manager.DeleteNote(noteId);
                if (result.Equals("Notes Deleted Successfully"))
                {
                    return this.Ok(new ResponseModel<string>() { status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { status = false, Message = ex.Message });
            }
        }
    }
}

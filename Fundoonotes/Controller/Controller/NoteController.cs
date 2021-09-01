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
        [HttpPut]
        [Route("api/changeColour")]
        public IActionResult ChangeNoteColor(int noteId, string noteColor)
        {
            try
            {
                string result = this.manager.ChangeNoteColor(noteId, noteColor);
                if (result.Equals("Colour Updated"))
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
        [HttpPut]
        [Route("api/changePin")]
        public IActionResult ChangePin(int noteId)
        {
            try
            {
                bool result = this.manager.ChangePin(noteId);
                if (result)
                {
                    return this.Ok(new ResponseModel<string>() { status = true, Message = "Pin Toggled" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { status = false, Message = "Error!!Note not Found" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { status = false, Message = ex.Message });
            }
        }
        [HttpPut]
        [Route("api/ChangeArchive")]
        public IActionResult Archive(int noteId)
        {
            try
            {
                bool result = this.manager.Archive(noteId);
                if (result)
                {
                    return this.Ok(new ResponseModel<string>() { status = true, Message = "Note Archived" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { status = false, Message = "Error!!Note not Found" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { status = false, Message = ex.Message });
            }
        }
    }
}

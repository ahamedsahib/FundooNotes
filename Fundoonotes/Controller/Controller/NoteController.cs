using Manager.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;

namespace Fundoonotes.Controller.Controller
{
    //[Authorize]
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
        [Route("api/deletenote")]
        public IActionResult DeleteNote(int noteId)
        {
            try
            {
                string result = this.manager.DeleteNote(noteId);
                if (result.Equals("Note Deleted"))
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
        [Route("api/Archive")]
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

        [HttpPut]
        [Route("api/toTrash")]
        public IActionResult MoveToTrash(int noteId)
        {
            try
            {
                bool result = this.manager.MoveToTrash(noteId);
                if (result)
                {
                    return this.Ok(new ResponseModel<string>() { status = true, Message = "Note Moved to Trash" });
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
        [Route("api/restoreNote")]
        public IActionResult RestoreNote(int noteId)
        {
            try
            {
                bool result = this.manager.RestoreNote(noteId);
                if (result)
                {
                    return this.Ok(new ResponseModel<string>() { status = true, Message = "Note Restored" });
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

        [HttpGet]
        [Route("api/getNote")]
        public IActionResult GetNote(int userId)
        {
            try
            {
                var result = this.manager.GetNote(userId);
                if (result.Count>0)
                {
                    return this.Ok(new ResponseModel<List<NotesModel>>() { status = true, Message = "All Notes are Succesfully Fetched", Data = result });
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
        [Route("api/updateNote")]
        public IActionResult UpdateNote(NotesModel noteData)
        {
            try
            {
                bool result = this.manager.UpdateNote(noteData);
                if (result)
                {
                    return this.Ok(new ResponseModel<string>() { status = true, Message = "Updated Succesfully" });
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
        [Route("api/setReminder")]
        public IActionResult SetReminder(int noteId, string addReminder)
        {
            try
            {
                bool result = this.manager.SetReminder(noteId,addReminder);
                if (result)
                {
                    return this.Ok(new ResponseModel<string>() { status = true, Message = "Reminder Set up Successfully" });
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
        [Route("api/unsetReminder")]
        public IActionResult UnsetReminder(int noteId)
        {
            try
            {
                bool result = this.manager.UnsetReminder(noteId);
                if (result)
                {
                    return this.Ok(new ResponseModel<string>() { status = true, Message = "Reminder removed" });
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
        [HttpGet]
        [Route("api/getReminder")]
        public IActionResult GetReminder(int userId)
        {
            try
            {
                var result = this.manager.GetReminder(userId);
                if (result.Count > 0)
                {
                    return this.Ok(new ResponseModel<List<NotesModel>>() { status = true, Message = "All Notes are Succesfully Fetched", Data = result });
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

        [HttpGet]
        [Route("api/getArchive")]
        public IActionResult GetArchive(int userId)
        {
            try
            {
                var result = this.manager.GetArchive(userId);
                if (result.Count > 0)
                {
                    return this.Ok(new ResponseModel<List<NotesModel>>() { status = true, Message = "All Notes are Succesfully Fetched", Data = result });
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

        [HttpGet]
        [Route("api/getTrash")]
        public IActionResult GetTrash(int userId)
        {
            try
            {
                var result = this.manager.GetTrash(userId);
                if (result.Count > 0)
                {
                    return this.Ok(new ResponseModel<List<NotesModel>>() { status = true, Message = "All Notes are Succesfully Fetched",Data=result});
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
        [HttpDelete]
        [Route("api/emptyTrash")]
        public IActionResult EmptyTrash(int userId)
        {
            try
            {
                bool result = this.manager.EmptyTrash(userId);
                if (result)
                {
                    return this.Ok(new ResponseModel<string>() { status = true, Message = "Trash is empty" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { status = false, Message = "Error!!Note not Found on trash" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { status = false, Message = ex.Message });
            }
        }
    }
}

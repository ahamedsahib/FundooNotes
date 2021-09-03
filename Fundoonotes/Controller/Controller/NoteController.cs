using Manager.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Collections.Generic;

namespace Fundoonotes.Controller.Controller
{
    [Authorize]
    public class NoteController : ControllerBase
    {
        private readonly INotesManager manager;

        private readonly ILogger<NoteController> _logger;

        public NoteController(INotesManager manager, ILogger<NoteController> logger)
        {
            this.manager = manager;
            _logger = logger;
        }

        [HttpPost]
        [Route("api/addnotes")]
        public IActionResult AddNote([FromBody] NotesModel noteData)
        {
            try
            {
                _logger.LogInformation("AddNote method called!!!");
                string result = this.manager.AddNote(noteData);
                if (result.Equals("Notes Addedd Successfully"))
                {
                    _logger.LogInformation($"UserId:{noteData.UserId}Added Note");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    _logger.LogInformation($"UserId:{noteData.UserId}Add Note Failed");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"UserId:{noteData.UserId}Error Occured While Adding Note");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/deletenote")]
        public IActionResult DeleteNote(int noteId)
        {
            try
            {
                _logger.LogInformation("DeleteNote method called!!!");
                string result = this.manager.DeleteNote(noteId);
                if (result.Equals("Note Deleted"))
                {
                    _logger.LogInformation($"NoteId:{noteId} Deleted ");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    _logger.LogInformation($"NoteId:{noteId} Deletion Failed ");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Error Occured While Deleting Note NoteId:{noteId}");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/changeColour")]
        public IActionResult ChangeNoteColor(int noteId, string noteColor)
        {
            try
            {
                _logger.LogInformation("ChangeNoteColor method called!!!");
                string result = this.manager.ChangeNoteColor(noteId, noteColor);
                if (result.Equals("Colour Updated"))
                {
                    _logger.LogInformation($"NoteId:{noteId} Note Color Changed");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    _logger.LogInformation($"NoteId:{noteId} Note Color Changed Unsuccessfull");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Error Ocuured While Changing Colour on NoteId:{noteId} ");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        [HttpPut]
        [Route("api/changePin")]
        public IActionResult ChangePin(int noteId)
        {
            try
            {
                _logger.LogInformation("Change Pin method called!!!");
                bool result = this.manager.ChangePin(noteId);
                if (result)
                {
                    _logger.LogInformation($"NoteId:{noteId} Toggled Pin");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Pin Toggled" });
                }
                else
                {
                    _logger.LogInformation($"NoteId:{noteId} Pin Toggled Failed");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Error!!Note not Found" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Error Ocuured While Changing Pin Function on NoteId:{noteId} ");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/Archive")]
        public IActionResult Archive(int noteId)
        {
            try
            {
                _logger.LogInformation("Archive method called!!!");
                bool result = this.manager.Archive(noteId);
                if (result)
                {
                    _logger.LogInformation($"NoteId:{noteId} Archived ");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Note Archived" });
                }
                else
                {
                    _logger.LogInformation($"NoteId:{noteId} Archived Failed ");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Error!!Note not Found" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Error!! Ocuured While Changing Archive on NoteId:{noteId} ");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/moveToTrash")]
        public IActionResult MoveToTrash(int noteId)
        {
            try
            {
                _logger.LogInformation("MoveToTrash method called!!!");
                bool result = this.manager.MoveToTrash(noteId);
                if (result)
                {
                    _logger.LogInformation($"NoteId:{noteId} Move to Trash ");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Note Moved to Trash" });
                }
                else
                {
                    _logger.LogInformation($"NoteId:{noteId} Move to Trash Failed");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Error!!Note not Found" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Error!! Ocuured While NoteId:{noteId} Moved to Trash ");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/restoreNote")]
        public IActionResult RestoreNote(int noteId)
        {
            try
            {
                _logger.LogInformation("RestoreNote method called!!!");
                bool result = this.manager.RestoreNote(noteId);
                if (result)
                {
                    _logger.LogInformation($"NoteId:{noteId} Restore From Trashed ");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Note Restored" });
                }
                else
                {
                    _logger.LogInformation($"NoteId:{noteId} Restore From Trashed Failed");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Error!!Note not Found" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Error!! Ocuured While NoteId:{noteId} Restored to Trash ");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/getNote")]
        public IActionResult GetNote(int userId)
        {
            try
            {
                _logger.LogInformation("GetNote method called!!!");
                var result = this.manager.GetNote(userId);
                if (result.Count>0)
                {
                    _logger.LogInformation($"UserId:{userId} Fetched All Note ");
                    return this.Ok(new ResponseModel<List<NotesModel>>() { Status = true, Message = "All Notes are Succesfully Fetched", Data = result });
                }
                else
                {
                    _logger.LogInformation($"UserId:{userId} Fetched All Note Failed  ");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Error!!Note not Found" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Error!! Ocuured While UserId:{userId} Getting All Notes ");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/updateNote")]
        public IActionResult UpdateNote(NotesModel noteData)
        {
            try
            {
                _logger.LogInformation("UpdateNote method called!!!");
                bool result = this.manager.UpdateNote(noteData);
                if (result)
                {
                    _logger.LogInformation($"UserId:{noteData.UserId} Update Note on NoteDd:{noteData.NoteId}");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Updated Succesfully" });
                }
                else
                {
                    _logger.LogInformation($"UserId:{noteData.UserId} Update Note on NoteDd:{noteData.NoteId} Failed");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Error!!Note not Found" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Error Ocuured While UserId:{noteData.UserId} Update Failed");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/setReminder")]
        public IActionResult SetReminder(int noteId, string addReminder)
        {
            try
            {
                _logger.LogInformation("SetReminder method called!!!");
                bool result = this.manager.SetReminder(noteId,addReminder);
                if (result)
                {
                    _logger.LogInformation($"NoteId:{noteId} Set new  Reminder");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Reminder Set up Successfully" });
                }
                else
                {
                    _logger.LogInformation($"NoteId:{noteId} Set new Reminder Failed");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Error!!Note not Found" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Error Ocuured While NoteId:{noteId} setting Reminder ");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/unsetReminder")]
        public IActionResult UnsetReminder(int noteId)
        {
            try
            {
                _logger.LogInformation("UnsetReminder method called!!!");
                bool result = this.manager.UnsetReminder(noteId);
                if (result)
                {
                    _logger.LogInformation($"NoteId:{noteId} Unset Reminder");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Reminder removed" });
                }
                else
                {
                    _logger.LogInformation($"NoteId:{noteId} Unset Reminder Failed");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Error!!Note not Found" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Error Ocuured While NoteId:{noteId} Unsetting Reminder ");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/getReminder")]
        public IActionResult GetReminder(int userId)
        {
            try
            {
                _logger.LogInformation("GetReminder method called!!");
                var result = this.manager.GetReminder(userId);
                if (result.Count > 0)
                {
                    _logger.LogInformation($"UserId:{userId} Get All Notes in Reminder");
                    return this.Ok(new ResponseModel<List<NotesModel>>() { Status = true, Message = "All Notes are Succesfully Fetched", Data = result });
                }
                else
                {
                    _logger.LogInformation($"UserId:{userId} Get All Notes in Reminder Failed");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Error!!No Note Found on Reminder" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Error Ocuured While UserId:{userId} Getting All Notes in Reminder ");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/getArchive")]
        public IActionResult GetArchive(int userId)
        {
            try
            {
                _logger.LogInformation("GetArchive method called!!!");
                var result = this.manager.GetArchive(userId);
                if (result.Count > 0)
                {
                    _logger.LogInformation($"UserId:{userId} Get All Notes in Archive");
                    return this.Ok(new ResponseModel<List<NotesModel>>() { Status = true, Message = "All Notes are Succesfully Fetched", Data = result });
                }
                else
                {
                    _logger.LogInformation($"UserId:{userId} Get All Notes in Archive Failed");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Error!!No Note Found on Archive" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Error Ocuured While UserId:{userId} Getting All Notes in Archive ");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/getTrash")]
        public IActionResult GetTrash(int userId)
        {
            try
            {
                _logger.LogInformation("GetTrash method called!!!");
                var result = this.manager.GetTrash(userId);
                if (result.Count > 0)
                {
                    _logger.LogInformation($"UserId:{userId} Get All Notes in Trash");
                    return this.Ok(new ResponseModel<List<NotesModel>>() { Status = true, Message = "All Notes are Succesfully Fetched",Data=result});
                }
                else
                {
                    _logger.LogInformation($"UserId:{userId} Get All Notes in Trash Failed");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Error!!No Note Found on Trash" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Error Ocuured While UserId:{userId} Getting All Notes in Trash ");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/emptyTrash")]
        public IActionResult EmptyTrash(int userId)
        {
            try
            {
                _logger.LogInformation("EmptyTash method called!!!");
                bool result = this.manager.EmptyTrash(userId);
                if (result)
                {
                    _logger.LogInformation($"UserId:{userId} Empty Trash Folder");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Trash is empty" });
                }
                else
                {
                    _logger.LogInformation($"UserId:{userId} Empty Trash Folder Action Failed");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Error!!No Note Found on trash" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Error Ocuured While UserId:{userId} Deleting all Trash ");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}

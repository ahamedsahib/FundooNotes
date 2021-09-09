// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NoteController.cs" company="TVSNext">
//   Copyright © 2021 Company="TVSNext"
// </copyright>
// <creator name="Ahamed"/>
// ----------------------------------------------------------------------------------------------------------
namespace Fundoonotes.Controller.Controller
{
    using System;
    using System.Collections.Generic;
    using global::Manager.Interface;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using global::Models;

    /// <summary>
    /// NoteController class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />  
    [Authorize]
    public class NoteController : ControllerBase
    {
        /// <summary>
        /// The manager
        /// </summary>
        private readonly INotesManager manager;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<NoteController> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoteController"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        /// <param name="logger">The logger.</param>
        public NoteController(INotesManager manager, ILogger<NoteController> logger)
        {
            this.manager = manager;
             this.logger = logger;
        }

        /// <summary>
        /// Adds the note.
        /// </summary>
        /// <param name="noteData">The note data.</param>
        /// <returns>Notes Added Successfully or not</returns>
        [HttpPost]
        [Route("api/addnotes")]
        public IActionResult AddNote([FromBody] NotesModel noteData)
        {
            try
            {
                 this.logger.LogInformation("AddNote method called!!!");
                string result = this.manager.AddNote(noteData);
                if (result.Equals("Notes Addedd Successfully"))
                {
                     this.logger.LogInformation($"UserId:{noteData.UserId}Added Note");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                     this.logger.LogInformation($"UserId:{noteData.UserId}Add Note Failed");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                 this.logger.LogWarning($"UserId:{noteData.UserId}Error Occured While Adding Note");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Deletes the note.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>Note Deleted or not</returns>
        [HttpDelete]
        [Route("api/deletenote")]
        public IActionResult DeleteNote(int noteId)
        {
            try
            {
                 this.logger.LogInformation("DeleteNote method called!!!");
                string result = this.manager.DeleteNote(noteId);
                if (result.Equals("Note Deleted"))
                {
                     this.logger.LogInformation($"NoteId:{noteId} Deleted ");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                     this.logger.LogInformation($"NoteId:{noteId} Deletion Failed ");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                 this.logger.LogWarning($"Error Occured While Deleting Note NoteId:{noteId}");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Changes the color of the note.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <param name="noteColor">Color of the note.</param>
        /// <returns>color Changed or not</returns>
        [HttpPut]
        [Route("api/changeColour")]
        public IActionResult ChangeNoteColor(int noteId, string noteColor)
        {
            try
            {
                 this.logger.LogInformation("ChangeNoteColor method called!!!");
                string result = this.manager.ChangeNoteColor(noteId, noteColor);
                if (result.Equals("Colour Updated"))
                {
                     this.logger.LogInformation($"NoteId:{noteId} Note Color Changed");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                     this.logger.LogInformation($"NoteId:{noteId} Note Color Changed Unsuccessfull");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                 this.logger.LogWarning($"Error Ocuured While Changing Colour on NoteId:{noteId} ");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Changes the pin.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>return true if pin Toggled</returns>
        [HttpPut]
        [Route("api/changePin")]
        public IActionResult ChangePin(int noteId)
        {
            try
            {
                 this.logger.LogInformation("Change Pin method called!!!");
                bool result = this.manager.ChangePin(noteId);
                if (result)
                {
                     this.logger.LogInformation($"NoteId:{noteId} Toggled Pin");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Pin Toggled" });
                }
                else
                {
                     this.logger.LogInformation($"NoteId:{noteId} Pin Toggled Failed");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Error!!Note not Found" });
                }
            }
            catch (Exception ex)
            {
                 this.logger.LogWarning($"Error Ocuured While Changing Pin Function on NoteId:{noteId} ");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Archives the specified note identifier.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>true if Archived</returns>
        [HttpPut]
        [Route("api/Archive")]
        public IActionResult Archive(int noteId)
        {
            try
            {
                 this.logger.LogInformation("Archive method called!!!");
                bool result = this.manager.Archive(noteId);
                if (result)
                {
                     this.logger.LogInformation($"NoteId:{noteId} Archived ");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Note Archived" });
                }
                else
                {
                     this.logger.LogInformation($"NoteId:{noteId} Archived Failed ");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Error!!Note not Found" });
                }
            }
            catch (Exception ex)
            {
                 this.logger.LogWarning($"Error!! Ocuured While Changing Archive on NoteId:{noteId} ");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Moves to trash.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>return true if note moved to trash</returns>
        [HttpPut]
        [Route("api/moveToTrash")]
        public IActionResult MoveToTrash(int noteId)
        {
            try
            {
                 this.logger.LogInformation("MoveToTrash method called!!!");
                bool result = this.manager.MoveToTrash(noteId);
                if (result)
                {
                     this.logger.LogInformation($"NoteId:{noteId} Move to Trash ");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Note Moved to Trash" });
                }
                else
                {
                     this.logger.LogInformation($"NoteId:{noteId} Move to Trash Failed");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Error!!Note not Found" });
                }
            }
            catch (Exception ex)
            {
                 this.logger.LogWarning($"Error!! Ocuured While NoteId:{noteId} Moved to Trash ");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Restores the note.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>return true if note restored from trash</returns>
        [HttpPut]
        [Route("api/restoreNote")]
        public IActionResult RestoreNote(int noteId)
        {
            try
            {
                 this.logger.LogInformation("RestoreNote method called!!!");
                bool result = this.manager.RestoreNote(noteId);
                if (result)
                {
                     this.logger.LogInformation($"NoteId:{noteId} Restore From Trashed ");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Note Restored" });
                }
                else
                {
                     this.logger.LogInformation($"NoteId:{noteId} Restore From Trashed Failed");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Error!!Note not Found" });
                }
            }
            catch (Exception ex)
            {
                 this.logger.LogWarning($"Error!! Ocuured While NoteId:{noteId} Restored to Trash ");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Gets the note.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>All Notes</returns>
        [HttpGet]
        [Route("api/getNote")]
        public IActionResult GetNote(int userId)
        {
            try
            {
                 this.logger.LogInformation("GetNote method called!!!");
                var result = this.manager.GetNote(userId);
                if (result.Count > 0)
                {
                     this.logger.LogInformation($"UserId:{userId} Fetched All Note ");
                    return this.Ok(new ResponseModel<List<NotesModel>>() { Status = true, Message = "All Notes are Succesfully Fetched", Data = result });
                }
                else
                {
                     this.logger.LogInformation($"UserId:{userId} Fetched All Note Failed  ");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Error!!Note not Found" });
                }
            }
            catch (Exception ex)
            {
                 this.logger.LogWarning($"Error!! Ocuured While UserId:{userId} Getting All Notes ");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Updates the note.
        /// </summary>
        /// <param name="noteData">The note data.</param>
        /// <returns>return true if note updated Successfully</returns>
        [HttpPut]
        [Route("api/updateNote")]
        public IActionResult UpdateNote(NotesModel noteData)
        {
            try
            {
                 this.logger.LogInformation("UpdateNote method called!!!");
                bool result = this.manager.UpdateNote(noteData);
                if (result)
                {
                     this.logger.LogInformation($"UserId:{noteData.UserId} Update Note on NoteDd:{noteData.NoteId}");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Updated Succesfully" });
                }
                else
                {
                     this.logger.LogInformation($"UserId:{noteData.UserId} Update Note on NoteDd:{noteData.NoteId} Failed");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Error!!Note not Found" });
                }
            }
            catch (Exception ex)
            {
                 this.logger.LogWarning($"Error Ocuured While UserId:{noteData.UserId} Update Failed");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Sets the reminder.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <param name="addReminder">The add reminder.</param>
        /// <returns>return true if note Reminder set </returns>
        [HttpPut]
        [Route("api/setReminder")]
        public IActionResult SetReminder(int noteId, string addReminder)
        {
            try
            {
                 this.logger.LogInformation("SetReminder method called!!!");
                bool result = this.manager.SetReminder(noteId, addReminder);
                if (result)
                {
                     this.logger.LogInformation($"NoteId:{noteId} Set new  Reminder");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Reminder Set up Successfully" });
                }
                else
                {
                     this.logger.LogInformation($"NoteId:{noteId} Set new Reminder Failed");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Error!!Note not Found" });
                }
            }
            catch (Exception ex)
            {
                 this.logger.LogWarning($"Error Ocuured While NoteId:{noteId} setting Reminder ");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Unsets the reminder.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>return true if note reminder removed</returns>
        [HttpPut]
        [Route("api/unsetReminder")]
        public IActionResult UnsetReminder(int noteId)
        {
            try
            {
                 this.logger.LogInformation("UnsetReminder method called!!!");
                bool result = this.manager.UnsetReminder(noteId);
                if (result)
                {
                     this.logger.LogInformation($"NoteId:{noteId} Unset Reminder");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Reminder removed" });
                }
                else
                {
                     this.logger.LogInformation($"NoteId:{noteId} Unset Reminder Failed");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Error!!Note not Found" });
                }
            }
            catch (Exception ex)
            {
                 this.logger.LogWarning($"Error Ocuured While NoteId:{noteId} Unsetting Reminder ");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Gets the reminder.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>all notes with reminder</returns>
        [HttpGet]
        [Route("api/getReminder")]
        public IActionResult GetReminder(int userId)
        {
            try
            {
                 this.logger.LogInformation("GetReminder method called!!");
                var result = this.manager.GetReminder(userId);
                if (result.Count > 0)
                {
                     this.logger.LogInformation($"UserId:{userId} Get All Notes in Reminder");
                    return this.Ok(new ResponseModel<List<NotesModel>>() { Status = true, Message = "All Notes are Succesfully Fetched", Data = result });
                }
                else
                {
                     this.logger.LogInformation($"UserId:{userId} Get All Notes in Reminder Failed");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Error!!No Note Found on Reminder" });
                }
            }
            catch (Exception ex)
            {
                 this.logger.LogWarning($"Error Ocuured While UserId:{userId} Getting All Notes in Reminder ");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Gets the archive.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>all archive notes of user</returns>
        [HttpGet]
        [Route("api/getArchive")]
        public IActionResult GetArchive(int userId)
        {
            try
            {
                this.logger.LogInformation("GetArchive method called!!!");
                var result = this.manager.GetArchive(userId);
                if (result.Count > 0)
                {
                    this.logger.LogInformation($"UserId:{userId} Get All Notes in Archive");
                    return this.Ok(new ResponseModel<List<NotesModel>>() { Status = true, Message = "All Notes are Succesfully Fetched", Data = result });
                }
                else
                {
                    this.logger.LogInformation($"UserId:{userId} Get All Notes in Archive Failed");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Error!!No Note Found on Archive" });
                }
            }
            catch (Exception ex)
            {
                this.logger.LogWarning($"Error Ocuured While UserId:{userId} Getting All Notes in Archive ");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Gets the trash.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>all notes on trash</returns>
        [HttpGet]
        [Route("api/getTrash")]
        public IActionResult GetTrash(int userId)
        {
            try
            {
                this.logger.LogInformation("GetTrash method called!!!");
                var result = this.manager.GetTrash(userId);
                if (result.Count > 0)
                {
                    this.logger.LogInformation($"UserId:{userId} Get All Notes in Trash");
                    return this.Ok(new ResponseModel<List<NotesModel>>() { Status = true, Message = "All Notes are Succesfully Fetched", Data = result });
                }
                else
                {
                    this.logger.LogInformation($"UserId:{userId} Get All Notes in Trash Failed");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Error!!No Note Found on Trash" });
                }
            }
            catch (Exception ex)
            {
                this.logger.LogWarning($"Error Ocuured While UserId:{userId} Getting All Notes in Trash ");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Empties the trash.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>return true if all note deleted on trash</returns>
        [HttpDelete]
        [Route("api/emptyTrash")]
        public IActionResult EmptyTrash(int userId)
        {
            try
            {
                this.logger.LogInformation("EmptyTash method called!!!");
                bool result = this.manager.EmptyTrash(userId);
                if (result)
                {
                     this.logger.LogInformation($"UserId:{userId} Empty Trash Folder");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Trash is empty" });
                }
                else
                {
                    this.logger.LogInformation($"UserId:{userId} Empty Trash Folder Action Failed");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Error!!No Note Found on trash" });
                }
            }
            catch (Exception ex)
            {
                this.logger.LogWarning($"Error Ocuured While UserId:{userId} Deleting all Trash ");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Adds the image.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <param name="imagePath">The image path.</param>
        /// <returns>return true if image added to note</returns>
        [HttpPut]
        [Route("api/addImage")]
        public IActionResult AddImage(int noteId, IFormFile imagePath)
        {
            try
            {
                bool result = this.manager.AddImage(noteId, imagePath);
                if (result)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Image Uploaded" });
                }

                return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Error!!Image Uploaded Failed" });
            }
            catch (Exception ex)
            {
               return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Deletes the image.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>return true if note image deleted successfully </returns>
        [HttpPut]
        [Route("api/deleteImage")]
        public IActionResult DeleteImage(int noteId)
        { 
            try
            {
                bool result = this.manager.DeleteImage(noteId);
                if (result)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Image deleted Successfully" });
                }

                return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Error!!delete failed" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}

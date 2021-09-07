using Manager.Interface;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fundoonotes.Controller.Controller
{
    public class LabelController : ControllerBase
    {
        private readonly ILabelManager manager;

        public LabelController(ILabelManager manager)
        {
            this.manager = manager;
        }

        [HttpPost]
        [Route("api/addLabelToNote")]
        public IActionResult AddLabelToNote([FromBody] LabelModel labelData)
        {
            try
            {
                string result = this.manager.AddLabelToNote(labelData);
                if (result.Equals("Label Added Successfully"))
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

        [HttpPost]
        [Route("api/addLabelToUser")]
        public IActionResult AddLabelToUser([FromBody] LabelModel labelData)
        {
            try
            {
                string result = this.manager.AddLabelToUser(labelData);
                if (result.Equals("Label Added Successfully"))
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

        [HttpDelete]
        [Route("api/deleteLabelOnNote")]
        public IActionResult DeleteLabelOnNote(int LabelId)
        {
            try
            {
                bool result = this.manager.DeleteLabelOnNote(LabelId);
                if (result)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Label Deleted Successfully" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Label Deletion Failed " });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/deleteLabel")]
        public IActionResult DeleteLabel(int userId,string labelName)
        {
            try
            {
                bool result = this.manager.DeleteLabel( userId, labelName);
                if (result)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Label Deleted Successfully" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Label Deletion Failed " });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/editLabelName")]
        public IActionResult EditLabelName(int userId, string existinglabelName,string newLabelName)
        {
            try
            {
                bool result = this.manager.EditLabelName(userId, existinglabelName, newLabelName);
                if (result)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Label Name Updated Successfully" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Edit Label Failed !! Label Not Exist" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/getLabels")]
        public IActionResult GetLabels(int userId)
        {
            try
            {
                var result = this.manager.GetLabels(userId);
                if (result.Count>0)
                {
                    return this.Ok(new ResponseModel<List<string>>() { Status = true, Message = "All Labels are fetched Successfully" ,Data=result});
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Getting Labels Failed" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}

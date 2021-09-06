﻿using Manager.Interface;
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
        [HttpPost]
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
    }
}

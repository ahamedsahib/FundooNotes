using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    class ForgetPasswordModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Url { get; set; }
    }
}

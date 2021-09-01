namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    /// <summary>
    /// ForgetPasswordModel
    /// </summary>
    class ForgetPasswordModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Url { get; set; }
    }
}

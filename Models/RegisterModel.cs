// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegisterModel.cs" company="TVSNext">
//   Copyright © 2021 Company="TVSNext"
// </copyright>
// <creator name="Ahamed"/>
// ----------------------------------------------------------------------------------------------------------
namespace Fundoonotes.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// RegisterModel class
    /// </summary>
    public class RegisterModel
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
       [Key]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}

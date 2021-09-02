// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ForgetPasswordModel.cs" company="TVSNext">
//   Copyright © 2021 Company="TVSNext"
// </copyright>
// <creator name="Ahamed"/>
// ----------------------------------------------------------------------------------------------------------
namespace Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// ForgetPasswordModel class
    /// </summary>
    public class ForgetPasswordModel
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        [Required]
        public string Url { get; set; }
    }
}

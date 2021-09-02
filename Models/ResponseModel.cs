// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResponseModel.cs" company="TVSNext">
//   Copyright © 2021 Company="TVSNext"
// </copyright>
// <creator name="Ahamed"/>
// ----------------------------------------------------------------------------------------------------------
namespace Models
{
    /// <summary>
    /// ResponseModel class
    /// </summary>
    /// <typeparam name="T">generic type</typeparam>
    public class ResponseModel<T>
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ResponseModel{T}"/> is status.
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public T Data { get; set; }
    }
}

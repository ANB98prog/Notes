using System.ComponentModel.DataAnnotations;

namespace Notes.Identity.Models
{
    /// <summary>
    /// Login model
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// User name
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Form return url
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;

namespace Notes.Identity.Models
{
    /// <summary>
    /// User identity
    /// </summary>
    public class AppUser : IdentityUser
    {
        /// <summary>
        /// User's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// User's last name
        /// </summary>
        public string LastName { get; set; }
    }
}

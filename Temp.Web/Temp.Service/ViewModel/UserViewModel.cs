using System;
using Temp.DataAccess.Data;

namespace Temp.Service.ViewModel
{
    /// <summary>
    /// user view model
    /// </summary>
    public class UserViewModel
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// user name
        /// </summary>
        public string Username { get; set; }
        
        /// <summary>
        /// password
        /// </summary>
        public string Password { get; set; }        
        
        /// <summary>
        /// role of account
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// create date account
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Expired date account
        /// </summary>
        public DateTime ExpiredDate { get; set; }

        /// <summary>
        /// type of account
        /// </summary>
        public int Type { get; set; }

        public Role Role { get; set; }
    }
}
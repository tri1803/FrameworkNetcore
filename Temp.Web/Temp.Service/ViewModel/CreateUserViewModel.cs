using System.Collections.Generic;
using Temp.DataAccess.Data;

namespace Temp.Service.ViewModel
{
    public class CreateUserViewModel
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
        public int[] RoleId { get; set; }

        public List<Role> Roles { get; set; }
    }
}
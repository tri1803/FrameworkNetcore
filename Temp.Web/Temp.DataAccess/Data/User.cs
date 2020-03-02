using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Temp.DataAccess.Data
{
    /// <summary>
    /// Class User
    /// </summary>
    public class User
    {
        /// <summary>
        /// primary key id
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// user name
        /// </summary>
        [Column(TypeName = "nvarchar(50)")]
        public string Username { get; set; }
        
        /// <summary>
        /// passowrd
        /// </summary>
        [Column(TypeName = "nvarchar(50)")]
        public string Password { get; set; }
        
        /// <summary>
        /// expired date
        /// </summary>
        public DateTime? ExpiredDate { get; set; }
        
        /// <summary>
        /// create date
        /// </summary>
        public DateTime? CreateDate { get; set; }
        
        public int? Type { get; set; }
        
        /// <summary>
        /// Foreign key RoleId
        /// </summary>
        public int RoleId { get; set; }
        
        public Role Role { get; set; }
    }
}
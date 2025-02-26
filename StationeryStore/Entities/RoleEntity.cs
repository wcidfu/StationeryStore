using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationeryStore.Entities
{
    [Table("role")]
    public class Role
    {
        [Key] [Column("roleid")]
        public int RoleID { get; set; }

        [Column("rolename")]
        public string RoleName { get; set; }
        public ICollection<User> Users { get; set; }  // Navigation property
    }

}

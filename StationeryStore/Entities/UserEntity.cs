using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationeryStore.Entities
{
    [Table("User")]
    public class User
    {
        [Key] [Column("userid")]
        public int UserID { get; set; }

        [Column("usersurname")]
        public string UserSurname { get; set; }

        [Column("username")]
        public string UserName { get; set; }

        [Column("userpatronymic")]
        public string UserPatronymic { get; set; }

        [Column("userlogin")]
        public string UserLogin { get; set; }

        [Column("userpassword")]
        public string UserPassword { get; set; }

        [Column("userrole")]
        public int UserRole { get; set; }

        // Навигационное свойство
        [ForeignKey("UserRole")]
        public Role Role { get; set; }
    }
}

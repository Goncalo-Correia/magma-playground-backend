using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Model
{
    [Table("magma_user")]
    public class User
    {
        [Key]
        [Column("id")]
        public int id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(30)]
        [Column("name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(30)]
        [Column("last_name")]
        public string lastName { get; set; }
        
        [Required(ErrorMessage = "Email is required")]
        [MaxLength(100)]
        [Column("email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MaxLength(30)]
        [Column("password")]
        public string password { get; set; }

        [Column("created_on")]
        public DateTime createdOn { get; set; }

        [Column("updated_on")]
        public DateTime updatedOn { get; set; }

        public List<Project> projects { get; set; }

        public User()
        {
        }
    }
}

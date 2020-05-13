using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Model
{
    public class User
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string name { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string lastName { get; set; }
        
        [Required(ErrorMessage = "Email is requires")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string password { get; set; }

        public DateTime createdOn { get; set; }
        public DateTime updatedOn { get; set; }

        public User()
        {
            createdOn = DateTime.UtcNow;
            updatedOn = DateTime.UtcNow;
        }
    }
}

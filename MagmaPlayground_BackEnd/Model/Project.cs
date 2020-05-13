using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Model
{
    public class Project
    {
        [Key]
        public int Id;

        [Required(ErrorMessage = "Project name is required")]
        [MaxLength(30)]
        public string projectName { get; set; }

        public DateTime createdOn { get; set; }
        public DateTime updateOn { get; set; }

        public User User { get; set; }

        public List<Track> Tracks { get; set; }

        public Project()
        {
            createdOn = DateTime.UtcNow;
            updateOn = DateTime.UtcNow;
        }
    }
}

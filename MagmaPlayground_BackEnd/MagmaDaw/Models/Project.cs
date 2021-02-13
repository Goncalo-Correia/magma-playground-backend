using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Model
{
    [Table("project")]
    public class Project
    {
        [Key]
        [Column("id")]
        public int id { get; set; }

        [Required(ErrorMessage = "Project name is required")]
        [Column("name")]
        public string name { get; set; }

        [Column("created_on")]
        public DateTime createdOn { get; set; }

        [Column("updated_on")]
        public DateTime updatedOn { get; set; }

        [Column("is_template")]
        public bool isTemplate { get; set; }

        [Column("is_default")]
        public bool isDefault { get; set; }

        public List<Track> tracks { get; set; }

        public Project()
        {
        }
    }
}

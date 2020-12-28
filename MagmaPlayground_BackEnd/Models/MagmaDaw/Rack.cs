using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Model
{
    [Table("rack")]
    public class Rack
    {
        [Key]
        [Column("id")]
        public int id { get; set; }

        [Required(ErrorMessage = "Track id is required")]
        [Column("track_id")]
        public int trackId { get; set; }
        public Track track { get; set; }

        public List<Plugin> plugins { get; set; }

        public Rack()
        {

        }
    }
}

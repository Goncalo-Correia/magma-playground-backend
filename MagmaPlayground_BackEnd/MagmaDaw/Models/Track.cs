using MagmaPlayground_BackEnd.MagmaDaw.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Model
{
    [Table("track")]
    public class Track
    {
        [Key]
        [Column("id")]
        public int id { get; set; }

        [Required(ErrorMessage = "Order is required")]
        [Column("order")]
        public int order { get; set; }

        [Required(ErrorMessage = "Track name is required")]
        [Column("name")]
        public string name { get; set; }

        [Column("volume")]
        public decimal volume { get; set; }

        [Column("pan")]
        public decimal pan { get; set; }

        [Required(ErrorMessage = "Tracktype is required")]
        [Column("track_type_id")]
        public int trackTypeId { get; set; }
        public TrackType trackType { get; set; }

        [Required(ErrorMessage = "Project id is required")]
        [Column("project_id")]
        public int projectId { get; set; }
        public Project Project { get; set; }

        [Required(ErrorMessage = "Rack id is required")]
        [Column("rack_id")]
        public int rackId { get; set; }
        public Rack rack { get; set; }

        public Track()
        {

        }
    }
}

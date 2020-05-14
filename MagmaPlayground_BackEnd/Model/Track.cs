﻿using System;
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
        [MaxLength(30)]
        [Column("order")]
        public int order { get; set; }

        [Required(ErrorMessage = "Track name is required")]
        [Column("name")]
        public string name { get; set; }

        [Column("volume")]
        public decimal volume { get; set; }

        [Column("pan")]
        public decimal pan { get; set; }

        [Required]
        [Column("tracktype")]
        public TrackType trackType { get; set; }

        [Required]
        [Column("project_id")]
        public Project project { get; set; }

        [Column("rack_id")]
        public Rack rack { get; set; }

        public Track()
        {

        }
    }
}

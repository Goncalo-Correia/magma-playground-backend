using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Model
{
    public class Track
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Order is required")]
        public int order { get; set; }

        [Required(ErrorMessage = "Track name is required")]
        public string trackName { get; set; }

        public decimal volume { get; set; }
        public decimal pan { get; set; }

        public TrackType trackType { get; set; }
        public Rack rack { get; set; }

        public Track()
        {
            volume = 0;
            pan = 0;
        }
    }
}

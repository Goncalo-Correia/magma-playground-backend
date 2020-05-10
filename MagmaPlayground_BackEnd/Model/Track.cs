using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Model
{
    public class Track
    {
        public int Id { get; set; }
        public int order { get; set; }
        public string trackName { get; set; }
        public decimal volume { get; set; }
        public decimal pan { get; set; }
        public TrackType trackType { get; set; }
        public Rack rack { get; set; }

        public Track()
        {

        }
    }
}

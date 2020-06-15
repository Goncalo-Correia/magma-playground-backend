using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Utilities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Daos.Utilities
{
    public class Response
    {
        public string message { get; set; }
        public ResponseStatus responseStatus { get; set; }

        public User user { get; set; }
        public Project project { get; set; }
        public Track track { get; set; }
        public Rack rack { get; set; }
        public Plugin plugin { get; set; }
        public Sampler sampler { get; set; }
        public Synthesizer synthesizer { get; set; }
        public AudioEffect audioEffect { get; set; }

        public List<User> users { get; set; }
        public List<Project> projects { get; set; }
        public List<Track> tracks { get; set; }
        public List<Rack> racks { get; set; }
        public List<Plugin> plugins { get; set; }
        public List<Sampler> samplers { get; set; }
        public List<Synthesizer> synthesizers { get; set; }
        public List<AudioEffect> audioEffects { get; set; }

        public Response()
        {
        }
    }
}

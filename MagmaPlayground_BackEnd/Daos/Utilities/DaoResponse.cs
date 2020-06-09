using MagmaPlayground_BackEnd.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Daos.Utilities
{
    public class DaoResponse
    {
        public string message { get; set; }
        public bool isValid { get; set; }

        public User user { get; set; }
        public Project project { get; set; }
        public Track track { get; set; }
        public Rack rack { get; set; }
        public Plugin plugin { get; set; }
        public Sampler sampler { get; set; }
        public Synthesizer synthesizer { get; set; }
        public AudioEffect audioEffect { get; set; }

        public DaoResponse()
        {
            user = null;
            plugin = null;
            track = null;
            rack = null;
            plugin = null;
            sampler = null;
            synthesizer = null;
            audioEffect = null;
        }
    }
}

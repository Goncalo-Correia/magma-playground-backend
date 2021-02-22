using MagmaPlayground_BackEnd.MagmaDaw.Models;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.ResponseUtilities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.ResponseUtilities
{
    public class DawResponse
    {
        public Project project { get; set; }
        public Track track { get; set; }
        public Rack rack { get; set; }
        public Plugin plugin { get; set; }
        public Sampler sampler { get; set; }
        public Synthesizer synthesizer { get; set; }
        public AudioEffect audioEffect { get; set; }
        public TrackType trackType { get; set; }
        public PluginType pluginType { get; set; }
        public SynthesizerType synthesizerType { get; set; }
        public AudioEffectType audioEffectType { get; set; }

        public List<Project> projects { get; set; }
        public List<Track> tracks { get; set; }
        public List<Rack> racks { get; set; }
        public List<Plugin> plugins { get; set; }
        public List<Sampler> samplers { get; set; }
        public List<Synthesizer> synthesizers { get; set; }
        public List<AudioEffect> audioEffects { get; set; }
        public List<TrackType> trackTypes { get; set; }
        public List<PluginType> pluginTypes { get; set; }
        public List<SynthesizerType> synthesizerTypes { get; set; }
        public List<AudioEffectType> audioEffectTypes { get; set; }

        public string errorMessage { get; set; }
        public HttpStatusCode httpStatusCode { get; set; }

        public DawResponse()
        {
        }
    }
}

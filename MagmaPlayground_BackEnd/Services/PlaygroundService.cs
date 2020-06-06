using MagmaPlayground_BackEnd.Controllers;
using MagmaPlayground_BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Services
{
    public class PlaygroundService
    {
        private UserController userController;
        private ProjectController projectController;
        private TrackController trackController;
        private RackController rackController;
        private PluginController pluginController;
        private SamplerController samplerController;
        private SynthesizerController synthesizerController;
        private AudioEffectController audioEffectController;
    }
}

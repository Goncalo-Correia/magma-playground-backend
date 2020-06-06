using MagmaPlayground_BackEnd.Controllers;
using MagmaPlayground_BackEnd.Factories;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Services
{
    public class PlaygroundService
    {
        private MagmaDbContext magmaDbContext;

        private UserController userController;
        private ProjectController projectController;
        private TrackController trackController;
        private RackController rackController;
        private PluginController pluginController;
        private SamplerController samplerController;
        private SynthesizerController synthesizerController;
        private AudioEffectController audioEffectController;

        private TrackFactory trackFactory;

        public PlaygroundService (MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;

            this.userController = new UserController(magmaDbContext);
            this.projectController = new ProjectController(magmaDbContext);
            this.trackController = new TrackController(magmaDbContext);
            this.rackController = new RackController(magmaDbContext);
            this.pluginController = new PluginController(magmaDbContext);
            this.samplerController = new SamplerController(magmaDbContext);
            this.synthesizerController = new SynthesizerController(magmaDbContext);
            this.audioEffectController = new AudioEffectController(magmaDbContext);

            this.trackFactory = new TrackFactory(projectController, trackController, rackController);
        }

        public void CreateDefaultProject(int userId)
        {

        }
    }
}

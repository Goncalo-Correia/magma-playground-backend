using MagmaPlayground_BackEnd.Controllers;
using MagmaPlayground_BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Factories
{
    public class SynthesizerFactory
    {
        private PluginController pluginController;
        private SynthesizerController synthesizerController;

        private Synthesizer synthesizer;

        public SynthesizerFactory(PluginController pluginController, SynthesizerController synthesizerController)
        {
            this.pluginController = pluginController;
            this.synthesizerController = synthesizerController;
        }

        public Synthesizer BuildSynthesizer()
        {
            return synthesizer;
        }
    }
}

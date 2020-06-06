using MagmaPlayground_BackEnd.Controllers;
using MagmaPlayground_BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Factories
{
    public class SamplerFactory
    {
        private PluginController pluginController;
        private SamplerController samplerController;

        private Sampler sampler;

        public SamplerFactory(PluginController pluginController, SamplerController samplerController)
        {
            this.pluginController = pluginController;
            this.samplerController = samplerController;
        }

        public Sampler BuildSampler()
        {
            return sampler;
        }
    }
}

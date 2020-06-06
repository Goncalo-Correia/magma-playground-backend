using MagmaPlayground_BackEnd.Controllers;
using MagmaPlayground_BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Factories
{
    public class PluginFactory
    {
        private RackController rackController;
        private PluginController pluginController;
        private SamplerController samplerController;
        private SynthesizerController synthesizerController;
        private AudioEffectController AudioEffectController;

        private SamplerFactory samplerFactory;
        private SynthesizerFactory synthesizerFactory;
        private AudioEffectFactory audioEffectFactory;

        private Plugin plugin;
        private List<Plugin> plugins;

        private Rack rack;

        private int pluginsCount;
        private int order;

        public PluginFactory(RackController rackController, PluginController pluginController, SamplerController samplerController, SynthesizerController synthesizerController, AudioEffectController audioEffectController)
        {
            this.rackController = rackController;
            this.pluginController = pluginController;
            this.samplerController = samplerController;
            this.synthesizerController = synthesizerController;
            this.AudioEffectController = audioEffectController;
            this.plugins = new List<Plugin>();
        }

        public Plugin BuildPluginForRack(int rackId, PluginType pluginType)
        {
            return BuildPlugin(rackId, pluginType);
        }

        public List<Plugin> BuildPluginsForRack(int rackId, List<PluginType> pluginTypes, int numberOfPlugins)
        {
            for (int i = 0; i < numberOfPlugins; i++)
            {
                plugins.Add(BuildPlugin(rackId, pluginTypes[i]));
            }

            return plugins;
        }

        private Plugin BuildPlugin(int rackId, PluginType pluginType)
        {
            rack = rackController.GetRackById(rackId).Value;

            pluginsCount = pluginController.GetPluginsByRackId(rackId).Value.ToList().Count;
            order = pluginsCount + 1;

            plugin = new Plugin();
            plugin.pluginName = pluginType.ToString() + " " + order;
            plugin.order = order;

            plugin.rack = rack;
            plugin.rackId = rackId;

            if (pluginType == PluginType.SAMPLER)
            {

            }
            if (pluginType == PluginType.SYNTHESIZER)
            {

            }
            if (pluginType == PluginType.AUDIOEFFECT)
            {

            }

            return plugin;
        }
    }
}

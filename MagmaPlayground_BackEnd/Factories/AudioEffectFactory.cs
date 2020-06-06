using MagmaPlayground_BackEnd.Controllers;
using MagmaPlayground_BackEnd.Model;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Factories
{
    public class AudioEffectFactory
    {
        private PluginController pluginController;
        private AudioEffectController audioEffectController;

        private AudioEffect audioEffect;
        private List<AudioEffect> audioEffects;

        public AudioEffectFactory(PluginController pluginController, AudioEffectController audioEffectController)
        {
            this.pluginController = pluginController;
            this.audioEffectController = audioEffectController;
            this.audioEffects = new List<AudioEffect>();
        }

        public AudioEffect BuildAudioEffect(int pluginId)
        {
            return audioEffect;
        }

        public List<AudioEffect> BuildAudioEffects(int pluginId)
        {
            return audioEffects;
        }

    }
}

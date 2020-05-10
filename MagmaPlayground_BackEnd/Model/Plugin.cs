using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Model
{
    public class Plugin
    {
        public int Id { get; set; }
        public int order { get; set; }
        public PluginType pluginType { get; set; }
        public Sampler sampler { get; set; }
        public Synthesizer synthesizer { get; set; }
        public List<AudioEffect> AudioEffects { get; set; }

        public Plugin()
        {

        }
    }
}

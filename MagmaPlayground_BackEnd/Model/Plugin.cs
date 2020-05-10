using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Model
{
    public class Plugin
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Order is required")]
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

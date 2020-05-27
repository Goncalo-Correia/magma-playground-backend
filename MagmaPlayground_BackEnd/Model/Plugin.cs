using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Model
{
    [Table("plugin")]
    public class Plugin
    {
        [Key]
        [Column("id")]
        public int id { get; set; }

        [Required(ErrorMessage = "Order is required")]
        [Column("order")]
        public int order { get; set; }

        [Required(ErrorMessage = "Plugin type is required")]
        [Column("plugintype")]
        public PluginType pluginType { get; set; }

        [Required(ErrorMessage = "Plugin name is required")]
        [Column("plugin_name")]
        public string pluginName { get; set; }

        [Required(ErrorMessage = "Rack is required")]
        [Column("rack_id")]
        public int rackId { get; set; }
        public Rack rack { get; set; }

        [Column("sampler_id")]
        public int samplerId { get; set; }
        public Sampler sampler { get; set; }

        [Column("synthesizer_id")]
        public int synthesizerId { get; set; }
        public Synthesizer synthesizer { get; set; }

        public List<AudioEffect> audioEffects { get; set; }

        public Plugin()
        {

        }
    }
}

using MagmaPlayground_BackEnd.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Model
{
    [Table("synthesizer")]
    public class Synthesizer
    {
        [Key]
        [Column("id")]
        public int id { get; set; }

        [Required(ErrorMessage = "Plugin name is required")]
        [MaxLength(30)]
        [Column("name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Synthesizer type is required")]
        [Column("synthesizertype")]
        public SynthesizerType synthesizerType { get; set; }

        [Required(ErrorMessage = "Plugin is required")]
        [Column("plugin_id")]
        public int pluginId { get; set; }

        public Plugin plugin { get; set; }

        public Synthesizer()
        {

        }
    }
}

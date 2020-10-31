using MagmaPlayground_BackEnd.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Model
{
    [Table("audioeffect")]
    public class AudioEffect
    {
        [Key]
        [Column("id")]
        public int id { get; set; }

        [Required(ErrorMessage = "Order is required")]
        [Column("order")]
        public int order { get; set; }

        [Required(ErrorMessage = "Audio effect name is required")]
        [Column("name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Audio effect type is required")]
        [Column("audioeffect_type_id")]
        public AudioEffectType audioEffectType { get; set; }

        [Required(ErrorMessage = "Plugin is required")]
        [Column("plugin_id")]
        public int pluginId { get; set; }

        public AudioEffect()
        {

        }
    }
}

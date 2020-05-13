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
        public int Id { get; set; }

        [Required(ErrorMessage = "Audio effect name is required")]
        public string name { get; set; }

        public AudioEffectType audioEffectType { get; set; }

        public AudioEffect()
        {

        }
    }
}

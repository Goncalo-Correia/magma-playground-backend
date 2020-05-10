using MagmaPlayground_BackEnd.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Model
{
    public class Synthesizer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Plugin name is required")]
        public string name { get; set; }

        public SynthesizerType synthesizerType { get; set; }

        public Synthesizer()
        {

        }
    }
}

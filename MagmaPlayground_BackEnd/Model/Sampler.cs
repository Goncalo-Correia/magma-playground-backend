using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Model
{
    public class Sampler
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Sampler name is required")]
        public string name { get; set; }

        public Sampler()
        {

        }
    }
}

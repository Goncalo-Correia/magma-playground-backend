using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaDaw.Models
{
    public class AudioEffectType
    {
        [Table("audioeffect_type")]
        public class LiveFileType
        {
            [Key]
            [Column("id")]
            public int id { get; set; }

            [Column("name")]
            [DataType(DataType.Text)]
            [Required(ErrorMessage = "Name is required")]
            public string name { get; set; }

            [Column("description")]
            [DataType(DataType.Text)]
            public string description { get; set; }
        }
    }
}

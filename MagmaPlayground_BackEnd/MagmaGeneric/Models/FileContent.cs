using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Models.MagmaGeneric
{
    [Table("file_content")]
    public class FileContent
    {
        [Key]
        [Column("id")]
        public int id { get; set; }

        [Column("binary_data")]
        [DataType(DataType.Custom)]
        public byte binaryData { get; set; }
    }
}

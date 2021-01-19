using MagmaPlayground_BackEnd.Models.MagmaGeneric.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Models.MagmaGeneric
{
    [Table("file")]
    public class File
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

        [Column("created")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "CreatedOn is required")]
        public DateTime createdOn { get; set; }

        [Column("uploated_on")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "UpdatedOn is required")]
        public DateTime updatedOn { get; set; }

        [Column("file_type_id")]
        [ForeignKey("file_filetype_fkey")]
        [Required(ErrorMessage = "FileTypeId is required")]
        public int? fileTypeId { get; set; }
        public FileType fileType { get; set; }

        [Column("file_content_id")]
        [ForeignKey("file_filecontent_fkey")]
        public int? fileContentId { get; set; }
        public FileContent fileContent { get; set; }
    }
}

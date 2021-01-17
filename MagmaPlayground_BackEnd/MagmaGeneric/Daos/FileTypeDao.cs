using MagmaPlayground_BackEnd.MagmaDB.MagmaGeneric;
using MagmaPlayground_BackEnd.Models.MagmaGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaGeneric.Daos
{
    public class FileTypeDao
    {
        private MagmaGenericDbContext magmaGenericDbContext;

        public FileTypeDao(MagmaGenericDbContext magmaGenericDbContext)
        {
            this.magmaGenericDbContext = magmaGenericDbContext;
        }

        public FileType GetFileTypeById(int id)
        {
            return magmaGenericDbContext.Find<FileType>(id);
        }

        public FileType CreateFileType(FileType fileType)
        {
            return magmaGenericDbContext.Add<FileType>(fileType).Entity;
        }

        public FileType UpdateFileType(FileType fileType)
        {
            return magmaGenericDbContext.Update<FileType>(fileType).Entity;
        }

        public void DeleteFileType(FileType fileType)
        {
            magmaGenericDbContext.Remove<FileType>(fileType);
        }
    }
}

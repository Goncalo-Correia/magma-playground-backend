using MagmaPlayground_BackEnd.MagmaDB.MagmaGeneric;
using MagmaPlayground_BackEnd.Models.MagmaGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaGeneric.Daos
{
    public class FileContentDao
    {
        private MagmaGenericDbContext magmaGenericDbContext;

        public FileContentDao(MagmaGenericDbContext magmaGenericDbContext)
        {
            this.magmaGenericDbContext = magmaGenericDbContext;
        }

        public FileContent GetFileContentById(int id)
        {
            return magmaGenericDbContext.Find<FileContent>(id);
        }

        public FileContent CreateFileContent(FileContent fileContent)
        {
            return magmaGenericDbContext.Add<FileContent>(fileContent).Entity;
        }

        public FileContent UpdateFileContent(FileContent fileContent)
        {
            return magmaGenericDbContext.Update<FileContent>(fileContent).Entity;
        }

        public void DeleteFileContent(FileContent fileContent)
        {
            magmaGenericDbContext.Remove<FileContent>(fileContent);
        }
    }
}

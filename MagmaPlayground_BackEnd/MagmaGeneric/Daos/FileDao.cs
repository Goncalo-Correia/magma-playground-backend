using MagmaPlayground_BackEnd.MagmaDB.MagmaGeneric;
using MagmaPlayground_BackEnd.Models.MagmaGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaGeneric.Daos
{
    public class FileDao
    {
        private MagmaGenericDbContext magmaGenericDbContext;

        public FileDao(MagmaGenericDbContext magmaGenericDbContext)
        {
            this.magmaGenericDbContext = magmaGenericDbContext;
        }

        public File GetFileById(int id)
        {
            return magmaGenericDbContext.Find<File>(id);
        }

        public File CreateFile(File file)
        {
            file = magmaGenericDbContext.Add<File>(file).Entity;

            magmaGenericDbContext.SaveChanges();

            return file;
        }

        public File UpdateFile(File file)
        {
            file = magmaGenericDbContext.Update<File>(file).Entity;

            magmaGenericDbContext.SaveChanges();

            return file;
        }

        public void DeleteFile(File file)
        {
            magmaGenericDbContext.Remove<File>(file);

            magmaGenericDbContext.SaveChanges();
        }
    }
}

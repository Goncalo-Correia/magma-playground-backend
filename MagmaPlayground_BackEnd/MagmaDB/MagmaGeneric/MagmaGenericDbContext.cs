using MagmaPlayground_BackEnd.Models.MagmaGeneric;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaDB.MagmaGeneric
{
    public class MagmaGenericDbContext : DbContext
    {
        public MagmaGenericDbContext(DbContextOptions<MagmaGenericDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<File> Files { get; set; }
        public DbSet<FileType> FileTypes { get; set; }
        public DbSet<FileContent> FileContents { get; set; }
    }
}

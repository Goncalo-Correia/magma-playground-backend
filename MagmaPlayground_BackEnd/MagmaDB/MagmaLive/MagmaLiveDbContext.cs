using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagmaPlayground_BackEnd.Model.Configurations;
using MagmaPlayground_BackEnd.Models.MagmaLive;
using Microsoft.EntityFrameworkCore;

namespace MagmaPlayground_BackEnd.MagmaDB.MagmaLive.MagmaDbContext
{
    public class MagmaLiveDbContext : DbContext
    {
        public MagmaLiveDbContext(DbContextOptions<MagmaLiveDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Live> Lives { get; set; }
        public DbSet<LiveType> LiveTypes { get; set; }
        public DbSet<LiveFile> LiveFiles { get; set; }
        public DbSet<LiveFileType> LiveFileTypes { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagmaPlayground_BackEnd.Model.Configurations;
using Microsoft.EntityFrameworkCore;

namespace MagmaPlayground_BackEnd.Model.MagmaDbContext
{
    public class MagmaDbContext : DbContext
    {
        public MagmaDbContext(DbContextOptions<MagmaDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Rack> Racks { get; set; }
        public DbSet<Plugin> Plugins { get; set; }
        public DbSet<Sampler> Samplers { get; set; }
        public DbSet<Synthesizer> Synthesizers { get; set; }
        public DbSet<AudioEffect> AudioEffects { get; set; }

    }
}

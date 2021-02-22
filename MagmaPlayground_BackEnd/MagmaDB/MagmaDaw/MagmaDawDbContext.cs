using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagmaPlayground_BackEnd.MagmaDaw.Models;
using Microsoft.EntityFrameworkCore;

namespace MagmaPlayground_BackEnd.Model.MagmaDbContext
{
    public class MagmaDawDbContext : DbContext
    {
        public MagmaDawDbContext(DbContextOptions<MagmaDawDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("magma_daw");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Rack> Racks { get; set; }
        public DbSet<Plugin> Plugins { get; set; }
        public DbSet<Sampler> Samplers { get; set; }
        public DbSet<Synthesizer> Synthesizers { get; set; }
        public DbSet<AudioEffect> AudioEffects { get; set; }
        public DbSet<TrackType> TrackTypes { get; set; }
        public DbSet<PluginType> PluginTypes { get; set; }
        public DbSet<SynthesizerType> SynthesizerTypes { get; set; }
        public DbSet<AudioEffectType> AudioEffectTypes { get; set; }
    }
}

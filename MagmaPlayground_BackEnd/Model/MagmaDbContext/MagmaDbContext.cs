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

            modelBuilder.ApplyConfiguration(new ProjectConfiguration());

            modelBuilder.ApplyConfiguration(new TrackConfiguration());

            modelBuilder.ApplyConfiguration(new RackConfiguration());

            modelBuilder.ApplyConfiguration(new PluginConfiguration());

            modelBuilder.ApplyConfiguration(new SamplerConfiguration());

            modelBuilder.ApplyConfiguration(new SynthesizerConfiguration());

            modelBuilder.ApplyConfiguration(new AudioEffectConfiguration());

            modelBuilder.Entity<Project>()
                .HasOne(prop => prop.user)
                .WithMany(prop => prop.projects);

            modelBuilder.Entity<Track>()
                .HasOne(prop => prop.project)
                .WithMany(prop => prop.tracks);

            modelBuilder.Entity<Track>()
                .HasOne(prop => prop.rack)
                .WithOne(prop => prop.track);

            modelBuilder.Entity<Rack>()
                .HasOne(prop => prop.track)
                .WithOne(prop => prop.rack);

            modelBuilder.Entity<Plugin>()
                .HasOne(prop => prop.rack)
                .WithMany(prop => prop.plugins);

            modelBuilder.Entity<Sampler>()
                .HasOne(prop => prop.plugin)
                .WithOne(prop => prop.sampler);

            modelBuilder.Entity<Synthesizer>()
                .HasOne(prop => prop.plugin)
                .WithOne(prop => prop.synthesizer);

            modelBuilder.Entity<AudioEffect>()
                .HasOne(prop => prop.plugin)
                .WithMany(prop => prop.audioEffects);
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

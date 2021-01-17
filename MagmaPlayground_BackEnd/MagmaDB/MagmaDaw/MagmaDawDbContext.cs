using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagmaPlayground_BackEnd.Model.Configurations;
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
                .WithMany(prop => prop.projects)
                .HasForeignKey(prop => prop.userId)
                .HasConstraintName("project_user_fkey");

            modelBuilder.Entity<Track>()
                .HasOne(prop => prop.Project)
                .WithMany(prop => prop.tracks)
                .HasForeignKey(prop => prop.projectId)
                .HasConstraintName("track_project_fkey");

            modelBuilder.Entity<Plugin>()
                .HasOne(prop => prop.rack)
                .WithMany(prop => prop.plugins)
                .HasForeignKey(prop => prop.rackId)
                .HasConstraintName("plugin_rack_fkey");
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

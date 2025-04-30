using Configurator_PC.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Configurator_PC.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
        }

        public DbSet<Component> Components { get; set; }
        public DbSet<ComponentType> ComponentTypes { get; set; }
        public DbSet<ComponentParameter> ComponentParameters { get; set; }
        public DbSet<ParameterName> ParameterNames { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<ConfigurationComponent> ConfigurationComponents { get; set; }
        public DbSet<ComponentTypeParameterName> ComponentTypeParameterNames { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CompatibilityRule> CompatibilityRules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CompatibilityRule>()
                .HasOne(r => r.ComponentType1)
                .WithMany(t => t.RulesAsType1)
                .HasForeignKey(r => r.ComponentType1Id)
                .HasPrincipalKey(t => t.Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CompatibilityRule>()
                .HasOne(r => r.ComponentType2)
                .WithMany(t => t.RulesAsType2)
                .HasForeignKey(r => r.ComponentType2Id)
                .HasPrincipalKey(t => t.Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CompatibilityRule>()
                .HasOne(r => r.ParameterName)
                .WithMany(p => p.CompatibilityRules)
                .HasForeignKey(r => r.ParameterNameId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Configuration>()
                .HasOne(c => c.User)
                .WithMany(u => u.Configurations)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Component>().ToTable("components");
            modelBuilder.Entity<ComponentType>().ToTable("component_types");
            modelBuilder.Entity<ComponentParameter>().ToTable("parameters");
            modelBuilder.Entity<ParameterName>().ToTable("parameter_names");
            modelBuilder.Entity<Configuration>().ToTable("configurations");
            modelBuilder.Entity<ConfigurationComponent>().ToTable("configuration_components");
            modelBuilder.Entity<ComponentTypeParameterName>().ToTable("component_type_parameter_names");
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<CompatibilityRule>().ToTable("compatibility_rules");
        }

    }
}

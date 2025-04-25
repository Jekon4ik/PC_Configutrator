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
        public DbSet<Compatibility> Compatibilities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Compatibility>()
                .HasOne(c => c.Component1)
                .WithMany()
                .HasForeignKey(c => c.Component1Id)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Compatibility>()
                .HasOne(c => c.Component2)
                .WithMany()
                .HasForeignKey(c => c.Component2Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Component>().ToTable("components");
            modelBuilder.Entity<ComponentType>().ToTable("component_types");
            modelBuilder.Entity<ComponentParameter>().ToTable("parameters");
            modelBuilder.Entity<ParameterName>().ToTable("parameter_names");
            modelBuilder.Entity<Configuration>().ToTable("configurations");
            modelBuilder.Entity<ConfigurationComponent>().ToTable("configuration_components");
            modelBuilder.Entity<ComponentTypeParameterName>().ToTable("component_type_parameter_names");
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Compatibility>().ToTable("compatibility");
        }
    }
}

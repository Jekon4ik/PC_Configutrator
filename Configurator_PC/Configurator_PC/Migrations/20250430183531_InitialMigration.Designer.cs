﻿// <auto-generated />
using Configurator_PC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Configurator_PC.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250430183531_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Configurator_PC.Models.CompatibilityRule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ComponentType1Id")
                        .HasColumnType("integer");

                    b.Property<int>("ComponentType2Id")
                        .HasColumnType("integer");

                    b.Property<string>("Operator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ParameterNameId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ComponentType1Id");

                    b.HasIndex("ComponentType2Id");

                    b.HasIndex("ParameterNameId");

                    b.ToTable("compatibility_rules", (string)null);
                });

            modelBuilder.Entity("Configurator_PC.Models.Component", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("TypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("components", (string)null);
                });

            modelBuilder.Entity("Configurator_PC.Models.ComponentParameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ComponentId")
                        .HasColumnType("integer");

                    b.Property<int>("ParameterNameId")
                        .HasColumnType("integer");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ComponentId");

                    b.HasIndex("ParameterNameId");

                    b.ToTable("parameters", (string)null);
                });

            modelBuilder.Entity("Configurator_PC.Models.ComponentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("component_types", (string)null);
                });

            modelBuilder.Entity("Configurator_PC.Models.ComponentTypeParameterName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ParameterNameId")
                        .HasColumnType("integer");

                    b.Property<int>("TypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ParameterNameId");

                    b.HasIndex("TypeId");

                    b.ToTable("component_type_parameter_names", (string)null);
                });

            modelBuilder.Entity("Configurator_PC.Models.Configuration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("configurations", (string)null);
                });

            modelBuilder.Entity("Configurator_PC.Models.ConfigurationComponent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ComponentId")
                        .HasColumnType("integer");

                    b.Property<int>("ConfigurationId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ComponentId");

                    b.HasIndex("ConfigurationId");

                    b.ToTable("configuration_components", (string)null);
                });

            modelBuilder.Entity("Configurator_PC.Models.ParameterName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("parameter_names", (string)null);
                });

            modelBuilder.Entity("Configurator_PC.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Configurator_PC.Models.CompatibilityRule", b =>
                {
                    b.HasOne("Configurator_PC.Models.ComponentType", "ComponentType1")
                        .WithMany("RulesAsType1")
                        .HasForeignKey("ComponentType1Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Configurator_PC.Models.ComponentType", "ComponentType2")
                        .WithMany("RulesAsType2")
                        .HasForeignKey("ComponentType2Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Configurator_PC.Models.ParameterName", "ParameterName")
                        .WithMany("CompatibilityRules")
                        .HasForeignKey("ParameterNameId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ComponentType1");

                    b.Navigation("ComponentType2");

                    b.Navigation("ParameterName");
                });

            modelBuilder.Entity("Configurator_PC.Models.Component", b =>
                {
                    b.HasOne("Configurator_PC.Models.ComponentType", "Type")
                        .WithMany("Components")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Configurator_PC.Models.ComponentParameter", b =>
                {
                    b.HasOne("Configurator_PC.Models.Component", "Component")
                        .WithMany("Parameters")
                        .HasForeignKey("ComponentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Configurator_PC.Models.ParameterName", "ParameterName")
                        .WithMany("ComponentParameters")
                        .HasForeignKey("ParameterNameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Component");

                    b.Navigation("ParameterName");
                });

            modelBuilder.Entity("Configurator_PC.Models.ComponentTypeParameterName", b =>
                {
                    b.HasOne("Configurator_PC.Models.ParameterName", "ParameterName")
                        .WithMany("ComponentTypeLinks")
                        .HasForeignKey("ParameterNameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Configurator_PC.Models.ComponentType", "Type")
                        .WithMany("AllowedParameterNames")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParameterName");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Configurator_PC.Models.Configuration", b =>
                {
                    b.HasOne("Configurator_PC.Models.User", "User")
                        .WithMany("Configurations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("User");
                });

            modelBuilder.Entity("Configurator_PC.Models.ConfigurationComponent", b =>
                {
                    b.HasOne("Configurator_PC.Models.Component", "Component")
                        .WithMany("ConfigurationComponents")
                        .HasForeignKey("ComponentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Configurator_PC.Models.Configuration", "Configuration")
                        .WithMany("ConfigurationComponents")
                        .HasForeignKey("ConfigurationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Component");

                    b.Navigation("Configuration");
                });

            modelBuilder.Entity("Configurator_PC.Models.Component", b =>
                {
                    b.Navigation("ConfigurationComponents");

                    b.Navigation("Parameters");
                });

            modelBuilder.Entity("Configurator_PC.Models.ComponentType", b =>
                {
                    b.Navigation("AllowedParameterNames");

                    b.Navigation("Components");

                    b.Navigation("RulesAsType1");

                    b.Navigation("RulesAsType2");
                });

            modelBuilder.Entity("Configurator_PC.Models.Configuration", b =>
                {
                    b.Navigation("ConfigurationComponents");
                });

            modelBuilder.Entity("Configurator_PC.Models.ParameterName", b =>
                {
                    b.Navigation("CompatibilityRules");

                    b.Navigation("ComponentParameters");

                    b.Navigation("ComponentTypeLinks");
                });

            modelBuilder.Entity("Configurator_PC.Models.User", b =>
                {
                    b.Navigation("Configurations");
                });
#pragma warning restore 612, 618
        }
    }
}

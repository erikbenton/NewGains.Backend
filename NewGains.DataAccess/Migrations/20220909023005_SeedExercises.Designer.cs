﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewGains.DataAccess.Contexts;

#nullable disable

namespace NewGains.DataAccess.Migrations
{
    [DbContext(typeof(NewGainsDbContext))]
    [Migration("20220909023005_SeedExercises")]
    partial class SeedExercises
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NewGains.Core.Entities.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BodyPart")
                        .HasColumnType("int");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Exercises");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BodyPart = 2,
                            Category = 0,
                            Name = "Bench Press"
                        },
                        new
                        {
                            Id = 2,
                            BodyPart = 1,
                            Category = 3,
                            Name = "Pull Up"
                        },
                        new
                        {
                            Id = 3,
                            BodyPart = 4,
                            Category = 0,
                            Name = "Squat"
                        },
                        new
                        {
                            Id = 4,
                            BodyPart = 5,
                            Category = 0,
                            Name = "Over Head Press"
                        },
                        new
                        {
                            Id = 5,
                            BodyPart = 0,
                            Category = 1,
                            Name = "Curls"
                        },
                        new
                        {
                            Id = 6,
                            BodyPart = 4,
                            Category = 4,
                            Name = "Outdoor Running"
                        });
                });

            modelBuilder.Entity("NewGains.Core.Entities.Instruction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int>("StepNumber")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("Instructions");
                });

            modelBuilder.Entity("NewGains.Core.Entities.Instruction", b =>
                {
                    b.HasOne("NewGains.Core.Entities.Exercise", null)
                        .WithMany("Instructions")
                        .HasForeignKey("ExerciseId");
                });

            modelBuilder.Entity("NewGains.Core.Entities.Exercise", b =>
                {
                    b.Navigation("Instructions");
                });
#pragma warning restore 612, 618
        }
    }
}
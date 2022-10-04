﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewGains.DataAccess.Contexts;

#nullable disable

namespace NewGains.DataAccess.Migrations
{
    [DbContext(typeof(NewGainsDbContext))]
    partial class NewGainsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

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

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int>("StepNumber")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("Instructions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ExerciseId = 1,
                            StepNumber = 1,
                            Text = "Lie flat on the bench holding the barbell with a shoulder width pronated grip."
                        },
                        new
                        {
                            Id = 2,
                            ExerciseId = 1,
                            StepNumber = 2,
                            Text = "Retract scapula and have elbows between 45 to 90 degree angle.\r\n						 Try to tuck the shoulders down into their sockets and driven back."
                        },
                        new
                        {
                            Id = 3,
                            ExerciseId = 1,
                            StepNumber = 3,
                            Text = "Lift bar from the rack and hold above the chest with arms extended."
                        },
                        new
                        {
                            Id = 4,
                            ExerciseId = 1,
                            StepNumber = 4,
                            Text = "Breathe in and lower bar to the middle chest."
                        },
                        new
                        {
                            Id = 5,
                            ExerciseId = 1,
                            StepNumber = 5,
                            Text = "After pausing at the bottom, push the bar towards the starting position squeezing the chest."
                        },
                        new
                        {
                            Id = 6,
                            ExerciseId = 1,
                            StepNumber = 6,
                            Text = "Repeat for reps"
                        },
                        new
                        {
                            Id = 7,
                            ExerciseId = 2,
                            StepNumber = 1,
                            Text = "Hold the pull up bar with a neutral grip with arms fully extended."
                        },
                        new
                        {
                            Id = 8,
                            ExerciseId = 2,
                            StepNumber = 2,
                            Text = "Retract scapula and pull upward by bringing chest to the bar."
                        },
                        new
                        {
                            Id = 9,
                            ExerciseId = 2,
                            StepNumber = 3,
                            Text = "Pause at the top and squeeze the back before lowering slowly to the starting position."
                        },
                        new
                        {
                            Id = 10,
                            ExerciseId = 2,
                            StepNumber = 4,
                            Text = "Repeat for reps"
                        });
                });

            modelBuilder.Entity("NewGains.Core.Entities.Template", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Templates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Push"
                        });
                });

            modelBuilder.Entity("NewGains.Core.Entities.TemplateSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<double?>("PercentIntensity")
                        .HasColumnType("float");

                    b.Property<int?>("Reps")
                        .HasColumnType("int");

                    b.Property<int>("SetGroupId")
                        .HasColumnType("int");

                    b.Property<int>("SetNumber")
                        .HasColumnType("int");

                    b.Property<int?>("TimeInSeconds")
                        .HasColumnType("int");

                    b.Property<double?>("WeightInPounds")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("SetGroupId");

                    b.ToTable("TemplateSets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ExerciseId = 1,
                            SetGroupId = 1,
                            SetNumber = 1
                        },
                        new
                        {
                            Id = 5,
                            ExerciseId = 1,
                            SetGroupId = 1,
                            SetNumber = 2
                        },
                        new
                        {
                            Id = 9,
                            ExerciseId = 1,
                            SetGroupId = 1,
                            SetNumber = 3
                        },
                        new
                        {
                            Id = 2,
                            ExerciseId = 2,
                            SetGroupId = 2,
                            SetNumber = 1
                        },
                        new
                        {
                            Id = 6,
                            ExerciseId = 2,
                            SetGroupId = 2,
                            SetNumber = 2
                        },
                        new
                        {
                            Id = 10,
                            ExerciseId = 2,
                            SetGroupId = 2,
                            SetNumber = 3
                        },
                        new
                        {
                            Id = 3,
                            ExerciseId = 4,
                            SetGroupId = 3,
                            SetNumber = 1
                        },
                        new
                        {
                            Id = 7,
                            ExerciseId = 4,
                            SetGroupId = 3,
                            SetNumber = 2
                        },
                        new
                        {
                            Id = 11,
                            ExerciseId = 4,
                            SetGroupId = 3,
                            SetNumber = 3
                        },
                        new
                        {
                            Id = 4,
                            ExerciseId = 3,
                            SetGroupId = 4,
                            SetNumber = 1
                        },
                        new
                        {
                            Id = 8,
                            ExerciseId = 3,
                            SetGroupId = 4,
                            SetNumber = 2
                        },
                        new
                        {
                            Id = 12,
                            ExerciseId = 3,
                            SetGroupId = 4,
                            SetNumber = 3
                        });
                });

            modelBuilder.Entity("NewGains.Core.Entities.TemplateSetGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("SetGroupNumber")
                        .HasColumnType("int");

                    b.Property<int>("TemplateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("TemplateId");

                    b.ToTable("TemplateSetGroups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ExerciseId = 1,
                            SetGroupNumber = 1,
                            TemplateId = 1
                        },
                        new
                        {
                            Id = 2,
                            ExerciseId = 2,
                            SetGroupNumber = 2,
                            TemplateId = 1
                        },
                        new
                        {
                            Id = 3,
                            ExerciseId = 4,
                            SetGroupNumber = 3,
                            TemplateId = 1
                        },
                        new
                        {
                            Id = 4,
                            ExerciseId = 3,
                            SetGroupNumber = 4,
                            TemplateId = 1
                        });
                });

            modelBuilder.Entity("NewGains.Core.Entities.Instruction", b =>
                {
                    b.HasOne("NewGains.Core.Entities.Exercise", "Exercise")
                        .WithMany("Instructions")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("NewGains.Core.Entities.TemplateSet", b =>
                {
                    b.HasOne("NewGains.Core.Entities.Exercise", "Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewGains.Core.Entities.TemplateSetGroup", "SetGroup")
                        .WithMany("Sets")
                        .HasForeignKey("SetGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("SetGroup");
                });

            modelBuilder.Entity("NewGains.Core.Entities.TemplateSetGroup", b =>
                {
                    b.HasOne("NewGains.Core.Entities.Exercise", "Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewGains.Core.Entities.Template", "Template")
                        .WithMany("SetGroups")
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("Template");
                });

            modelBuilder.Entity("NewGains.Core.Entities.Exercise", b =>
                {
                    b.Navigation("Instructions");
                });

            modelBuilder.Entity("NewGains.Core.Entities.Template", b =>
                {
                    b.Navigation("SetGroups");
                });

            modelBuilder.Entity("NewGains.Core.Entities.TemplateSetGroup", b =>
                {
                    b.Navigation("Sets");
                });
#pragma warning restore 612, 618
        }
    }
}

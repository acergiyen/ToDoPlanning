﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ToDoPlanning.Data;

#nullable disable

namespace ToDoPlanning.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240208220817_developer2")]
    partial class developer2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ToDoPlanning.Data.Entities.Developer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Developers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capacity = 1,
                            Name = "Dev1"
                        },
                        new
                        {
                            Id = 2,
                            Capacity = 2,
                            Name = "Dev2"
                        },
                        new
                        {
                            Id = 3,
                            Capacity = 3,
                            Name = "Dev3"
                        },
                        new
                        {
                            Id = 4,
                            Capacity = 4,
                            Name = "Dev4"
                        },
                        new
                        {
                            Id = 5,
                            Capacity = 5,
                            Name = "Dev5"
                        });
                });

            modelBuilder.Entity("ToDoPlanning.Data.Entities.TaskItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DeveloperId")
                        .HasColumnType("integer");

                    b.Property<int>("Difficulty")
                        .HasColumnType("integer");

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperId");

                    b.ToTable("TaskItems");
                });

            modelBuilder.Entity("ToDoPlanning.Data.Entities.TaskItem", b =>
                {
                    b.HasOne("ToDoPlanning.Data.Entities.Developer", "Developer")
                        .WithMany("Tasks")
                        .HasForeignKey("DeveloperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Developer");
                });

            modelBuilder.Entity("ToDoPlanning.Data.Entities.Developer", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}

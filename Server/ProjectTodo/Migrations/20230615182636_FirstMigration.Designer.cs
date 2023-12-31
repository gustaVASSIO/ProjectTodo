﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectTodo.Context;

#nullable disable

namespace ProjectTodo.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230615182636_FirstMigration")]
    partial class FirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ProjectTask.Models.Entities.Todo", b =>
                {
                    b.Property<string>("ProductId")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("DateConclusion")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.ToTable("Todos");
                });
#pragma warning restore 612, 618
        }
    }
}

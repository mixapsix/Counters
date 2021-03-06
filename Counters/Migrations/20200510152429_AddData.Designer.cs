﻿// <auto-generated />
using Counters.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Counters.Migrations
{
    [DbContext(typeof(CountersContext))]
    [Migration("20200510152429_AddData")]
    partial class AddData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Counters.Counter", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("Counters");

                    b.HasData(
                        new
                        {
                            ID = -7,
                            Number = 1,
                            Value = 1
                        },
                        new
                        {
                            ID = -6,
                            Number = 1,
                            Value = 2
                        },
                        new
                        {
                            ID = -5,
                            Number = 1,
                            Value = 3
                        },
                        new
                        {
                            ID = -4,
                            Number = 2,
                            Value = 1
                        },
                        new
                        {
                            ID = -3,
                            Number = 2,
                            Value = 1
                        },
                        new
                        {
                            ID = -2,
                            Number = 2,
                            Value = 3
                        },
                        new
                        {
                            ID = -1,
                            Number = 2,
                            Value = 1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

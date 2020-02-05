﻿// <auto-generated />
using Counters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Counters.Migrations
{
    [DbContext(typeof(CountersContext))]
    [Migration("20200203181817_AddData")]
    partial class AddData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Counters.Counter", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ID")
                        .HasColumnType("integer");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Number");

                    b.ToTable("Counters");

                    b.HasData(
                        new
                        {
                            Number = 1,
                            ID = 1,
                            Value = 1
                        },
                        new
                        {
                            Number = 2,
                            ID = 1,
                            Value = 2
                        },
                        new
                        {
                            Number = 3,
                            ID = 1,
                            Value = 3
                        },
                        new
                        {
                            Number = 4,
                            ID = 2,
                            Value = 1
                        },
                        new
                        {
                            Number = 5,
                            ID = 2,
                            Value = 1
                        },
                        new
                        {
                            Number = 6,
                            ID = 2,
                            Value = 3
                        },
                        new
                        {
                            Number = 7,
                            ID = 2,
                            Value = 1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
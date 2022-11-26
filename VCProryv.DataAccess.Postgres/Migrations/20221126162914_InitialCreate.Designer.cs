﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VCProryv.DataAccess.Postgres;

#nullable disable

namespace VCProryv.DataAccess.Postgres.Migrations
{
    [DbContext(typeof(VCProryvDbContext))]
    [Migration("20221126162914_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ActivityVolunteer", b =>
                {
                    b.Property<int>("ActivitiesId")
                        .HasColumnType("integer");

                    b.Property<int>("VolunteersId")
                        .HasColumnType("integer");

                    b.HasKey("ActivitiesId", "VolunteersId");

                    b.HasIndex("VolunteersId");

                    b.ToTable("ActivityVolunteer");
                });

            modelBuilder.Entity("VCProryv.DataAccess.Postgres.Entities.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("VCProryv.DataAccess.Postgres.Entities.Volunteer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Institute")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Volunteers");
                });

            modelBuilder.Entity("ActivityVolunteer", b =>
                {
                    b.HasOne("VCProryv.DataAccess.Postgres.Entities.Activity", null)
                        .WithMany()
                        .HasForeignKey("ActivitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VCProryv.DataAccess.Postgres.Entities.Volunteer", null)
                        .WithMany()
                        .HasForeignKey("VolunteersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

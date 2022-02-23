﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using pet_hotel.Models;

namespace dotnet_bakery.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("pet_hotel.PetOwner", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
                   
                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");
                        
                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");
                        
                    b.HasKey("id");

                    b.ToTable("PetOwners");
                    
                    });
                    
            modelBuilder.Entity("pet_hotel.Pet", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
                        
                    b.Property<int>("breed")
                        .HasColumnType("integer");

                    b.Property<DateTime>("checkedInAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("color")
                        .HasColumnType("integer");

                    b.Property<int>("petOwnerid")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("Pets");

                });
#pragma warning restore 612, 618
        }
    }
}

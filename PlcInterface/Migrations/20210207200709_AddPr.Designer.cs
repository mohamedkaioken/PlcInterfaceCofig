﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlcInterface.Context;

namespace PlcInterface.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210207200709_AddPr")]
    partial class AddPr
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("PlcInterface.Models.ConfigOne", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("BrokerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Co2")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Fault")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("H2O")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("MachineId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<decimal>("Syrp")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ConfigsOne");
                });

            modelBuilder.Entity("PlcInterface.Models.ConfigThree", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("BrokerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Fault")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("MachineId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PackCount")
                        .HasColumnType("int");

                    b.Property<int>("PallateCount")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ConfigsThree");
                });

            modelBuilder.Entity("PlcInterface.Models.ConfigTwo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("ActualSpeed")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("BrokerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("CO2")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Fault")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("MachineId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MachineMode")
                        .HasColumnType("int");

                    b.Property<decimal>("MixVolume")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProdTime")
                        .HasColumnType("int");

                    b.Property<int>("ProductionCount")
                        .HasColumnType("int");

                    b.Property<int>("ProgramSelection")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ConfigsTwo");
                });
#pragma warning restore 612, 618
        }
    }
}
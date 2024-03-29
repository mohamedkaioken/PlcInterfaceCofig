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
    [Migration("20210802110658_AddCount")]
    partial class AddCount
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("PlcInterface.Models.Blow_Moulder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Count_In")
                        .HasColumnType("int");

                    b.Property<int>("Count_Out")
                        .HasColumnType("int");

                    b.Property<string>("Factory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Fault")
                        .HasColumnType("int");

                    b.Property<int>("Line")
                        .HasColumnType("int");

                    b.Property<string>("MachineId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Pressure")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Production_Hours")
                        .HasColumnType("int");

                    b.Property<decimal>("Speed")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<decimal>("Temperature")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Blow_Moulders");
                });

            modelBuilder.Entity("PlcInterface.Models.Cartonizer_Shrink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Counts")
                        .HasColumnType("int");

                    b.Property<string>("Factory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Fault")
                        .HasColumnType("int");

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.Property<int>("Line")
                        .HasColumnType("int");

                    b.Property<string>("MachineId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Speed")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Cartonizers_Shrinks");
                });

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

                    b.ToTable("ConfigOne");
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

                    b.ToTable("ConfigThree");
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

                    b.ToTable("ConfigTwo");
                });

            modelBuilder.Entity("PlcInterface.Models.DPalletizer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Factory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Fault")
                        .HasColumnType("int");

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.Property<int>("Line")
                        .HasColumnType("int");

                    b.Property<string>("MachineId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Speed")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("DPalletizers");
                });

            modelBuilder.Entity("PlcInterface.Models.Filler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Alarms")
                        .HasColumnType("int");

                    b.Property<decimal>("Co2_Consumption")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Factory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Fault")
                        .HasColumnType("int");

                    b.Property<int>("Line")
                        .HasColumnType("int");

                    b.Property<string>("MachineId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Mix_select")
                        .HasColumnType("int");

                    b.Property<decimal>("Mix_vol")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Production_Hours")
                        .HasColumnType("int");

                    b.Property<int>("Rinse")
                        .HasColumnType("int");

                    b.Property<decimal>("Speed")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Fillers");
                });

            modelBuilder.Entity("PlcInterface.Models.Label", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Counts")
                        .HasColumnType("int");

                    b.Property<string>("Factory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Fault")
                        .HasColumnType("int");

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.Property<int>("Line")
                        .HasColumnType("int");

                    b.Property<string>("MachineId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Speed")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Labels");
                });

            modelBuilder.Entity("PlcInterface.Models.Mixer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("Co2_Consumption")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Factory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Fault")
                        .HasColumnType("int");

                    b.Property<int>("Line")
                        .HasColumnType("int");

                    b.Property<string>("MachineId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Product_Consumption")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Production_Hours")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<decimal>("Syrup_Consumption")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Water_Consumption")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Mixers");
                });

            modelBuilder.Entity("PlcInterface.Models.Palletizer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Factory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Fault")
                        .HasColumnType("int");

                    b.Property<int>("Line")
                        .HasColumnType("int");

                    b.Property<string>("MachineId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Packet_No")
                        .HasColumnType("int");

                    b.Property<int>("Pallet_No")
                        .HasColumnType("int");

                    b.Property<int>("Production_Hours")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Palletizers");
                });
#pragma warning restore 612, 618
        }
    }
}

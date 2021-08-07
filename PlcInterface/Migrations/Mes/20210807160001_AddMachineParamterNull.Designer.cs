﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlcInterface.Context;

namespace PlcInterface.Migrations.Mes
{
    [DbContext(typeof(MesContext))]
    [Migration("20210807160001_AddMachineParamterNull")]
    partial class AddMachineParamterNull
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("PlcInterface.Models.CocaMesModels.Factory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Factories");
                });

            modelBuilder.Entity("PlcInterface.Models.CocaMesModels.Load", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("EnergyCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FactoryId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlcCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductionLineId")
                        .HasColumnType("int");

                    b.Property<string>("SignalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UtilityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FactoryId");

                    b.HasIndex("ProductionLineId");

                    b.HasIndex("UtilityId");

                    b.ToTable("Loads");
                });

            modelBuilder.Entity("PlcInterface.Models.CocaMesModels.MachineParameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("MachineCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParameterName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MachineParameters");
                });

            modelBuilder.Entity("PlcInterface.Models.CocaMesModels.ProductionLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("FactoryId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FactoryId");

                    b.ToTable("ProductionLines");
                });

            modelBuilder.Entity("PlcInterface.Models.CocaMesModels.Utility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("FactoryId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FactoryId");

                    b.ToTable("Utilities");
                });

            modelBuilder.Entity("PlcInterface.Models.CocaMesModels.Load", b =>
                {
                    b.HasOne("PlcInterface.Models.CocaMesModels.Factory", "Factory")
                        .WithMany("Loads")
                        .HasForeignKey("FactoryId");

                    b.HasOne("PlcInterface.Models.CocaMesModels.ProductionLine", "ProductionLine")
                        .WithMany("Loads")
                        .HasForeignKey("ProductionLineId");

                    b.HasOne("PlcInterface.Models.CocaMesModels.Utility", "Utility")
                        .WithMany("Loads")
                        .HasForeignKey("UtilityId");

                    b.Navigation("Factory");

                    b.Navigation("ProductionLine");

                    b.Navigation("Utility");
                });

            modelBuilder.Entity("PlcInterface.Models.CocaMesModels.ProductionLine", b =>
                {
                    b.HasOne("PlcInterface.Models.CocaMesModels.Factory", "Factory")
                        .WithMany("ProductionLines")
                        .HasForeignKey("FactoryId");

                    b.Navigation("Factory");
                });

            modelBuilder.Entity("PlcInterface.Models.CocaMesModels.Utility", b =>
                {
                    b.HasOne("PlcInterface.Models.CocaMesModels.Factory", "Factory")
                        .WithMany("Utilities")
                        .HasForeignKey("FactoryId");

                    b.Navigation("Factory");
                });

            modelBuilder.Entity("PlcInterface.Models.CocaMesModels.Factory", b =>
                {
                    b.Navigation("Loads");

                    b.Navigation("ProductionLines");

                    b.Navigation("Utilities");
                });

            modelBuilder.Entity("PlcInterface.Models.CocaMesModels.ProductionLine", b =>
                {
                    b.Navigation("Loads");
                });

            modelBuilder.Entity("PlcInterface.Models.CocaMesModels.Utility", b =>
                {
                    b.Navigation("Loads");
                });
#pragma warning restore 612, 618
        }
    }
}

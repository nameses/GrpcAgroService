﻿// <auto-generated />
using GrpcAgroService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GrpcAgroService.Migrations
{
    [DbContext(typeof(ServerDbContext))]
    [Migration("20230504220734_DoubleRework")]
    partial class DoubleRework
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GrpcAgroService.Models.AgroFieldModel", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Aria")
                        .HasColumnType("int");

                    b.Property<int>("Azot")
                        .HasColumnType("int");

                    b.Property<int>("Bal")
                        .HasColumnType("int");

                    b.Property<double>("Cesium")
                        .HasColumnType("float");

                    b.Property<double>("Cobalt")
                        .HasColumnType("float");

                    b.Property<double>("Copper")
                        .HasColumnType("float");

                    b.Property<double>("Gumus")
                        .HasColumnType("float");

                    b.Property<double>("Kaliy")
                        .HasColumnType("float");

                    b.Property<double>("Lead")
                        .HasColumnType("float");

                    b.Property<int>("Manganese")
                        .HasColumnType("int");

                    b.Property<double>("PH")
                        .HasColumnType("float");

                    b.Property<int>("Phosfor")
                        .HasColumnType("int");

                    b.Property<double>("StrontiumMax")
                        .HasColumnType("float");

                    b.Property<double>("StrontiumMin")
                        .HasColumnType("float");

                    b.Property<double>("Zinc")
                        .HasColumnType("float");

                    b.HasKey("Name");

                    b.ToTable("AgroFields");
                });
#pragma warning restore 612, 618
        }
    }
}
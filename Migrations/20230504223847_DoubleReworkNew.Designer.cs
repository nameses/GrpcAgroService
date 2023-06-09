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
    [Migration("20230504223847_DoubleReworkNew")]
    partial class DoubleReworkNew
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

                    b.Property<double>("Aria")
                        .HasColumnType("float");

                    b.Property<double>("Azot")
                        .HasColumnType("float");

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

                    b.Property<double>("Manganese")
                        .HasColumnType("float");

                    b.Property<double>("PH")
                        .HasColumnType("float");

                    b.Property<double>("Phosfor")
                        .HasColumnType("float");

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

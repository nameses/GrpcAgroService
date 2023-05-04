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
    [Migration("20230504203816_init")]
    partial class init
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

                    b.Property<int>("Cesium")
                        .HasColumnType("int");

                    b.Property<int>("Cobalt")
                        .HasColumnType("int");

                    b.Property<int>("Copper")
                        .HasColumnType("int");

                    b.Property<int>("Gumus")
                        .HasColumnType("int");

                    b.Property<int>("Kaliy")
                        .HasColumnType("int");

                    b.Property<int>("Lead")
                        .HasColumnType("int");

                    b.Property<int>("Manganese")
                        .HasColumnType("int");

                    b.Property<int>("PH")
                        .HasColumnType("int");

                    b.Property<int>("Phosfor")
                        .HasColumnType("int");

                    b.Property<int>("Strontium")
                        .HasColumnType("int");

                    b.Property<int>("Zinc")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.ToTable("AgroFields");
                });
#pragma warning restore 612, 618
        }
    }
}
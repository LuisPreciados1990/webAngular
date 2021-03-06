﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebSystem.Models;

namespace WebSystem.Migrations
{
    [DbContext(typeof(ApplicationDbContextRoot))]
    [Migration("20190325203728_dp01a110")]
    partial class dp01a110
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebSystem.Models.Formas.CNT.DP01A110", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo");

                    b.Property<string>("Codigo_Aux");

                    b.Property<string>("Detalle");

                    b.Property<string>("Estado");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("DP01A110");
                });

            modelBuilder.Entity("WebSystem.Models.main.Gestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo");

                    b.Property<string>("Namebmp");

                    b.Property<string>("Nombre");

                    b.Property<string>("NombreCorto");

                    b.HasKey("Id");

                    b.ToTable("WebGestiones");
                });

            modelBuilder.Entity("WebSystem.Models.main.Programa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Describe");

                    b.Property<string>("GesApl");

                    b.Property<string>("Msg");

                    b.Property<string>("Nombre");

                    b.Property<string>("Opciones");

                    b.Property<string>("Orden");

                    b.Property<string>("Tarea");

                    b.HasKey("Id");

                    b.ToTable("WebProgramas");
                });

            modelBuilder.Entity("WebSystem.Models.main.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<DateTime>("FechaModificacion");

                    b.Property<string>("UserId");

                    b.Property<string>("UserLog");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("WebUsuarios");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Context;

namespace Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211220154416_tabelaEmpresa")]
    partial class tabelaEmpresa
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entidades.Empresa", b =>
                {
                    b.Property<int>("CodigoEmpresa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.HasKey("CodigoEmpresa");

                    b.ToTable("Empresa");
                });
#pragma warning restore 612, 618
        }
    }
}

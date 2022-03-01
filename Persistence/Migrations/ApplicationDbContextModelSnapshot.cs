﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Context;

namespace Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entidades.CategoriaEquipamento", b =>
                {
                    b.Property<int>("CodigoCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CodigoCategoria");

                    b.ToTable("CategoriaEquipamento");
                });

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

            modelBuilder.Entity("Domain.Entidades.Equipamento", b =>
                {
                    b.Property<int>("CodigoTipoEquipamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodigoCategoria")
                        .HasColumnType("int");

                    b.Property<int>("CodigoFabricante")
                        .HasColumnType("int");

                    b.Property<string>("TipoEquipamento")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CodigoTipoEquipamento");

                    b.HasIndex("CodigoCategoria");

                    b.HasIndex("CodigoFabricante");

                    b.ToTable("Equipamento");
                });

            modelBuilder.Entity("Domain.Entidades.Fabricante", b =>
                {
                    b.Property<int>("CodigoFabricante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeFabricante")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("CodigoFabricante");

                    b.ToTable("Fabricante");
                });

            modelBuilder.Entity("Domain.Entidades.Funcionario", b =>
                {
                    b.Property<int>("CodigoFuncionario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("NomeFuncionario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodigoFuncionario");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("Domain.Entidades.InformacaoAdicional", b =>
                {
                    b.Property<int>("CodigoInformacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Antivirus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CodigoPatrimonio")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCompra")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataExpericaoGarantia")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ValorPago")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("VersaoWindows")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodigoInformacao");

                    b.HasIndex("CodigoPatrimonio");

                    b.ToTable("InformacaoAdicional");
                });

            modelBuilder.Entity("Domain.Entidades.MovimentacaoEquipamento", b =>
                {
                    b.Property<int>("CodigoMovimentacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodigoPatrimonio")
                        .HasColumnType("int");

                    b.Property<int>("CodigoUsuario")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataApropriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataEvolucao")
                        .HasColumnType("datetime2");

                    b.Property<int>("MovimentacaoDoEquipamento")
                        .HasColumnType("int");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodigoMovimentacao");

                    b.HasIndex("CodigoPatrimonio");

                    b.HasIndex("CodigoUsuario");

                    b.ToTable("MovimentacaoEquipamento");
                });

            modelBuilder.Entity("Domain.Entidades.Patrimonio", b =>
                {
                    b.Property<int>("CodigoPatrimonio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Armazenamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CodigoTipoEquipamento")
                        .HasColumnType("int");

                    b.Property<int>("CodigoUsuario")
                        .HasColumnType("int");

                    b.Property<string>("MAC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemoriaRAM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlacaDeVideo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Processador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceTag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SituacaoEquipamento")
                        .HasColumnType("int");

                    b.HasKey("CodigoPatrimonio");

                    b.HasIndex("CodigoTipoEquipamento");

                    b.HasIndex("CodigoUsuario");

                    b.ToTable("Patrimonio");
                });

            modelBuilder.Entity("Domain.Entidades.PercaEquipamento", b =>
                {
                    b.Property<int>("CodigoPerca")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodigoPatrimonio")
                        .HasColumnType("int");

                    b.Property<string>("MotivoDaPerca")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("CodigoPerca");

                    b.HasIndex("CodigoPatrimonio");

                    b.ToTable("PercaEquipamento");
                });

            modelBuilder.Entity("Domain.Entidades.PerfilUsuario", b =>
                {
                    b.Property<int>("CodigoUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescricaoPermissao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagemUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeSetor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RazaoSocial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodigoUsuario");

                    b.ToTable("PerfilUsuario");
                });

            modelBuilder.Entity("Domain.Entidades.Setor", b =>
                {
                    b.Property<int>("CodigoSetor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CodigoSetor");

                    b.ToTable("Setor");
                });

            modelBuilder.Entity("Domain.Entidades.Usuario", b =>
                {
                    b.Property<int>("CodigoUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int?>("CodigoEmpresa")
                        .HasColumnType("int");

                    b.Property<int?>("CodigoSetor")
                        .HasColumnType("int");

                    b.Property<int>("CodigoUsuarioPermissao")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagemUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("CodigoUsuario");

                    b.HasIndex("CodigoEmpresa");

                    b.HasIndex("CodigoSetor");

                    b.HasIndex("CodigoUsuarioPermissao");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Domain.Entidades.UsuarioPermissao", b =>
                {
                    b.Property<int>("CodigoUsuarioPermissao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("DescricaoPermissao")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("CodigoUsuarioPermissao");

                    b.ToTable("UsuarioPermissao");
                });

            modelBuilder.Entity("Domain.Entidades.Equipamento", b =>
                {
                    b.HasOne("Domain.Entidades.CategoriaEquipamento", "Categoria")
                        .WithMany()
                        .HasForeignKey("CodigoCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entidades.Fabricante", "Fabricante")
                        .WithMany()
                        .HasForeignKey("CodigoFabricante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Fabricante");
                });

            modelBuilder.Entity("Domain.Entidades.InformacaoAdicional", b =>
                {
                    b.HasOne("Domain.Entidades.Patrimonio", "Patrimonio")
                        .WithMany()
                        .HasForeignKey("CodigoPatrimonio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patrimonio");
                });

            modelBuilder.Entity("Domain.Entidades.MovimentacaoEquipamento", b =>
                {
                    b.HasOne("Domain.Entidades.Patrimonio", "Patrimonio")
                        .WithMany()
                        .HasForeignKey("CodigoPatrimonio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entidades.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("CodigoUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patrimonio");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Entidades.Patrimonio", b =>
                {
                    b.HasOne("Domain.Entidades.Equipamento", "Equipamento")
                        .WithMany()
                        .HasForeignKey("CodigoTipoEquipamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entidades.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("CodigoUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipamento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Entidades.PercaEquipamento", b =>
                {
                    b.HasOne("Domain.Entidades.Patrimonio", "Patrimonio")
                        .WithMany()
                        .HasForeignKey("CodigoPatrimonio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patrimonio");
                });

            modelBuilder.Entity("Domain.Entidades.Usuario", b =>
                {
                    b.HasOne("Domain.Entidades.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("CodigoEmpresa");

                    b.HasOne("Domain.Entidades.Setor", "Setor")
                        .WithMany()
                        .HasForeignKey("CodigoSetor");

                    b.HasOne("Domain.Entidades.UsuarioPermissao", "UsuarioPermissao")
                        .WithMany()
                        .HasForeignKey("CodigoUsuarioPermissao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("Setor");

                    b.Navigation("UsuarioPermissao");
                });
#pragma warning restore 612, 618
        }
    }
}

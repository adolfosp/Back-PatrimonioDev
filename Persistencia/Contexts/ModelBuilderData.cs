using Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Contexts
{
    public static class ModelBuilderData
    {
        public static void AdicionarInformacoesPadrao(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empresa>().HasData(new Empresa(1, "00.000.000/0000-00", "SEM EMPRESA", "SEM EMPRESA", false));
            modelBuilder.Entity<Funcionario>().HasData(new Funcionario(1, "SEM FUNCIONÁRIO", true, string.Empty));
            modelBuilder.Entity<Setor>().HasData(new Setor(1, "SEM SETOR"));
            modelBuilder.Entity<Usuario>().HasData(new Usuario(1,true,"ADOLFO", "MTIzNDU2","adolfo8799@gmail.com", "3f7143f59c222954756.jpg",1,1,1));
            modelBuilder.Entity<UsuarioPermissao>().HasData(new UsuarioPermissao[]{
                new UsuarioPermissao(1,"Administrador",true),
                new UsuarioPermissao(2,"Gestor",true),
                new UsuarioPermissao(3,"Usuário",true)

            });
        }

        public static void AdicionarRelacionamento(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity("Domain.Entidades.Equipamento", b =>
             {
                 b.HasOne("Domain.Entidades.CategoriaEquipamento", "Categoria")
                     .WithMany()
                     .HasForeignKey("CodigoCategoria")
                     .OnDelete(DeleteBehavior.Restrict)
                     .IsRequired();

                 b.HasOne("Domain.Entidades.Fabricante", "Fabricante")
                     .WithMany()
                     .HasForeignKey("CodigoFabricante")
                     .OnDelete(DeleteBehavior.Restrict)
                     .IsRequired();

                 b.Navigation("Categoria");

                 b.Navigation("Fabricante");
             });

            modelBuilder.Entity("Domain.Entidades.InformacaoAdicional", b =>
                {
                    b.HasOne("Domain.Entidades.Patrimonio", "Patrimonio")
                        .WithMany()
                        .HasForeignKey("CodigoPatrimonio")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Patrimonio");
                });

            modelBuilder.Entity("Domain.Entidades.MovimentacaoEquipamento", b =>
                {
                    b.HasOne("Domain.Entidades.Patrimonio", "Patrimonio")
                        .WithMany()
                        .HasForeignKey("CodigoPatrimonio")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entidades.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("CodigoUsuario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Patrimonio");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Entidades.Patrimonio", b =>
                {
                    b.HasOne("Domain.Entidades.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("CodigoFuncionario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entidades.Equipamento", "Equipamento")
                        .WithMany()
                        .HasForeignKey("CodigoTipoEquipamento")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entidades.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("CodigoUsuario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Equipamento");

                    b.Navigation("Funcionario");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Entidades.PerdaEquipamento", b =>
                {
                    b.HasOne("Domain.Entidades.Patrimonio", "Patrimonio")
                        .WithMany()
                        .HasForeignKey("CodigoPatrimonio")
                        .OnDelete(DeleteBehavior.Restrict)
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
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("Setor");

                    b.Navigation("UsuarioPermissao");
                });
        }
    }
}

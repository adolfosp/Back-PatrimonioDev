using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entidades
{
    public class Funcionario
    {

        public Funcionario()
        {
        }

        public Funcionario(int codigoFuncionario, string nomeFuncionario, bool ativo, string observacao)
        {
            CodigoFuncionario = codigoFuncionario;
            NomeFuncionario = nomeFuncionario;
            Ativo = ativo;
            Observacao = observacao;
        }

        [Key]
        public int CodigoFuncionario { get; set; }

        [Column(TypeName = "VARCHAR"),  StringLength(100), Required]
        public string NomeFuncionario { get; set; }

        [Column(TypeName = "BIT")]
        public bool Ativo { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(250)]
        public string? Observacao { get; set; }
    }
}

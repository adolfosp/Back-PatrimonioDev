using System.ComponentModel.DataAnnotations;

namespace Domain.Entidades
{
    public class Funcionario
    {
        [Key]
        public int CodigoFuncionario { get; set; }

        [Required(ErrorMessage = "Nome do funcionário é obrigatório")]
        [MaxLength(100)]
        [MinLength(10)]
        public string NomeFuncionario { get; set; }

        public bool Ativo { get; set; }

        public string Observacao { get; set; }
    }
}

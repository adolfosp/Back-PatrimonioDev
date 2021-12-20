using System.ComponentModel.DataAnnotations;

namespace Domain.Entidades
{
    public class Empresa
    {
        [Key]
        public int CodigoEmpresa { get; set; }

        [Required]
        [MaxLength(100)]
        public string NomeEmpresa { get; set; }

        [Required]
        [MaxLength(18)]
        public string CNPJ { get; set; }

        [Required]
        [MaxLength(100)]
        public string RazaoSocial { get; set; }

        [Required]
        [MaxLength(100)]
        public string NomeFantasia { get; set; }

    }
}

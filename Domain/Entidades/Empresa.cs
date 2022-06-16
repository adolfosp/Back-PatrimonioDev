using System.ComponentModel.DataAnnotations;

namespace Domain.Entidades
{
   
   
    public class Empresa
    {
        [Key]
        public int CodigoEmpresa { get; set; }

        [Required]
        [MaxLength(18)]
        public string CNPJ { get; set; }

        [Required]
        [MaxLength(70)]
        public string RazaoSocial { get; set; }

        [Required]
        [MaxLength(70)]
        public string NomeFantasia { get; set; }

        public bool EmpresaPadraoImpressao { get; set; }

    }
}

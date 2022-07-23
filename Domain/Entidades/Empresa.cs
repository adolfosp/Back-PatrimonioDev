using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entidades
{
    public class Empresa
    {

        public Empresa()
        {
        }

        public Empresa(int codigoEmpresa, string cNPJ, string razaoSocial, string nomeFantasia, bool empresaPadraoImpressao)
        {
            CodigoEmpresa = codigoEmpresa;
            CNPJ = cNPJ;
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            EmpresaPadraoImpressao = empresaPadraoImpressao;
        }

        [Key]
        public int CodigoEmpresa { get; set; }

        [MaxLength(18)]
        [Column(TypeName = "VARCHAR"), StringLength(18), Required]
        public string CNPJ { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(70), Required]
        public string RazaoSocial { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(70), Required]
        public string NomeFantasia { get; set; }

        [Column(TypeName = "BIT")]
        public bool EmpresaPadraoImpressao { get; set; }

    }
}

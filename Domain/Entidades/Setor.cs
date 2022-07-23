using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entidades
{
    public class Setor
    {
        public Setor()
        {
        }

        public Setor(int codigoSetor, string nome)
        {
            CodigoSetor = codigoSetor;
            Nome = nome;
        }

        [Key]
        public int CodigoSetor { get; set; }


        [Required, Column(TypeName = "VARCHAR"), StringLength(50)]
        public string Nome { get; set; }
    }
}

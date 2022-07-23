using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entidades
{
    public class Patrimonio
    {
        [Key]
        public int CodigoPatrimonio { get; set; }

        [Required, Column(TypeName = "VARCHAR"), StringLength(100)]
        public string Modelo { get; set; }

        [Required, Column(TypeName = "VARCHAR"), StringLength(20)]
        public string ServiceTag { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(60)]
        public string? Armazenamento { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(100)]
        public string? Processador { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(100)]
        public string? PlacaDeVideo { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(100)]
        public string? MAC { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(100)]
        public string? MemoriaRAM { get; set; }

        [Required]
        public SituacaoEquipamento SituacaoEquipamento { get; set; }

        [Required]
        public int CodigoTipoEquipamento { get; set; }
        [ForeignKey("CodigoTipoEquipamento")]
        public Equipamento Equipamento { get; set; }

        [Required]
        public int CodigoUsuario { get; set; }

        [ForeignKey("CodigoUsuario")]
        public Usuario Usuario { get; set; }

        [Required]
        public int CodigoFuncionario { get; set; }

        [ForeignKey("CodigoFuncionario")]
        public Funcionario Funcionario { get; set; }
    }
}

﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Aplicacao.Dtos
{
    public class MovimentacaoEquipamentoDto
    {
       

        [Display(Name = "Data de apropriação")]
        [Required(ErrorMessage = "É necessário informar a {0} do equipamento")]
        public DateTime DataApropriacao { get; set; }
        public DateTime? DataEvolucao { get; set; }
        public string? Observacao { get; set; }

        [Required]
        public int CodigoUsuario { get; set; }

        [Required]
        public int CodigoPatrimonio { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Aplicacao.Dtos
{
    public class EmpresaDto
    {
        [Required(ErrorMessage = "{0} precisa ser preenchido."),
            StringLength(18, MinimumLength = 5, ErrorMessage = "O intervalo de caracteres precisa estar entre 5 a 18.")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "{0} precisa ser preenchida."),
           StringLength(70, MinimumLength = 5, ErrorMessage = "O intervalo de caracteres precisa estar entre 5 a 70.")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "{0} precisa ser preenchida."),
            StringLength(70,MinimumLength = 5,ErrorMessage = "O intervalo de caracteres precisa estar entre 5 a 70.")]
        public string NomeFantasia { get; set; }
    }
}

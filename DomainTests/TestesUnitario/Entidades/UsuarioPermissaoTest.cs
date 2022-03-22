using Domain.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainTests.TestesUnitario.Entidades
{
    [TestClass]
    public class UsuarioPermissaoTest
    {
        [TestMethod]
        public void Retorna_falso_se_tamanho_maximo_estrapolar_no_campo_descricaoPermissao()
        {

            //Arrange
            var sut = new UsuarioPermissao();
            var context = new ValidationContext(sut) { MemberName = "DescricaoPermissao" };
            var results = new List<ValidationResult>();

            //Act
            var resultado = Validator.TryValidateProperty("lorem ipsum lorem ip ", context, results);

            //Assert
            Assert.IsFalse(resultado);

        }
        [TestMethod]
        public void Retorna_falso_se_campo_descricaoPermissao_foi_preenchido_e_tamanho_minimo_nao_respeitado()
        {

            //Arrange
            var sut = new UsuarioPermissao();
            var context = new ValidationContext(sut) { MemberName = "DescricaoPermissao" };
            var results = new List<ValidationResult>();

            //Act
            var resultado = Validator.TryValidateProperty("se", context, results);

            //Assert
            Assert.IsFalse(resultado);

        }
    }
}

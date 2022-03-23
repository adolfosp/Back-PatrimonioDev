using Domain.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainTests.TestesUnitario.Entidades
{
    [TestClass]
    public class SetorTest
    {
        [TestMethod]
        public void Retorna_falso_se_campo_nome_foi_preenchido_e_tamanho_minimo_nao_respeitado()
        {

            //Arrange
            var sut = new Setor();
            var context = new ValidationContext(sut) { MemberName = "Nome" };
            var results = new List<ValidationResult>();

            //Act
            var resultado = Validator.TryValidateProperty("set", context, results);

            //Assert
            Assert.IsFalse(resultado);

        }

        [TestMethod]
        public void Retorna_falso_se_tamanho_maximo_estrapolar_no_campo_nome()
        {

            //Arrange
            var sut = new Setor();
            var context = new ValidationContext(sut) { MemberName = "Nome" };
            var results = new List<ValidationResult>();

            //Act
            var resultado = Validator.TryValidateProperty("lorem ipsum lorem ipsum lorem ipsum lorem ipsum    ", context, results);

            //Assert
            Assert.IsFalse(resultado);

        }
    }
}

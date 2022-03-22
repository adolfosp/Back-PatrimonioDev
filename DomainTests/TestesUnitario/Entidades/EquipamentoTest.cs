using Domain.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainTests.TestesUnitario.Entidades
{
    [TestClass]
    public class EquipamentoTest
    {

        [TestMethod]
        public void Retorna_falso_se_tamanho_minimo_nao_preenchido_do_campo_tipoEquipamento()
        {

            //Arrange
            var sut = new Equipamento();
            var context = new ValidationContext(sut) { MemberName = "TipoEquipamento" };
            var results = new List<ValidationResult>();

            //Act
            var resultado = Validator.TryValidateProperty("equi", context, results);

            //Assert
            Assert.IsFalse(resultado);

        }

        [TestMethod]
        public void Retorna_falso_se_tamanho_maximo_estrapolar_no_campo_tipoEquipamento()
        {

            //Arrange
            var sut = new Equipamento();
            var context = new ValidationContext(sut) { MemberName = "TipoEquipamento" };
            var results = new List<ValidationResult>();

            //Act
            var resultado = Validator.TryValidateProperty("lorem ipsum lorem ipsum lorem ipsum lorem ipsum lor", context, results);

            //Assert
            Assert.IsFalse(resultado);

        }
    }
}

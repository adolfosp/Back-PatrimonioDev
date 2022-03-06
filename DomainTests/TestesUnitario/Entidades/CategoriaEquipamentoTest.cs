using Domain.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainTests.TestesUnitario.Entidades
{
    [TestClass]
    public class CategoriaEquipamentoTest
    {

        [TestMethod]
        public void Retorna_verdadeiro_se_campo_descricao_foi_preenchido_e_tamanho_minimo_preenchido()
        {

            //Arrange
            var sut = new CategoriaEquipamento();
            var context = new ValidationContext(sut) { MemberName = "Descricao" };
            var results = new List<ValidationResult>();

            //Act
            var resultado = Validator.TryValidateProperty("setor", context, results);

            //Assert
            Assert.IsTrue(resultado);

        }

        [TestMethod]
        public void Retorna_falso_se_campo_descricao_foi_preenchido_e_tamanho_minimo_nao_preenchido()
        {

            //Arrange
            var sut = new CategoriaEquipamento();
            var context = new ValidationContext(sut) { MemberName = "Descricao" };
            var results = new List<ValidationResult>();

            //Act
            var resultado = Validator.TryValidateProperty("seto", context, results);

            //Assert
            Assert.IsFalse(resultado);

        }

        [TestMethod]
        public void Retorna_mensagem_caso_nao_for_preenchido()
        {

            //Arrange
            var sut = new CategoriaEquipamento();
            var context = new ValidationContext(sut) { MemberName = "Descricao" };
            var results = new List<ValidationResult>();

            //Act
            Validator.TryValidateProperty("", context, results);

            //Assert
            Assert.AreEqual("A descrição é obrigatória", results[0].ErrorMessage);

        }
    }
}

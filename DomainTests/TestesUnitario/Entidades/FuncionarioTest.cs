using Domain.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainTests.TestesUnitario.Entidades
{
    [TestClass]
    public class FuncionarioTest
    {
        [TestMethod]
        public void Retorna_mensagem_caso_campo_nao_for_preenchido()
        {

            //Arrange
            var sut = new Funcionario();
            var context = new ValidationContext(sut) { MemberName = "NomeFuncionario" };
            var results = new List<ValidationResult>();

            //Act
            Validator.TryValidateProperty("", context, results);

            //Assert
            Assert.AreEqual("Nome do funcionário é obrigatório", results[0].ErrorMessage);

        }

        [TestMethod]
        public void Retorna_falso_se_tamanho_maximo_estrapolar_no_campo_nomeFuncionario()
        {

            //Arrange
            var sut = new Funcionario();
            var context = new ValidationContext(sut) { MemberName = "NomeFuncionario" };
            var results = new List<ValidationResult>();

            //Act
            var resultado = Validator.TryValidateProperty("lorem ipsum lorem lorem ipsum lorem lorem ipsum lorem lorem ipsum lorem lorem ipsum lorem lorem ipsu ", context, results);

            //Assert
            Assert.IsFalse(resultado);

        }

        [TestMethod]
        public void Retorna_falso_se_campo_nomeFuncionario_foi_preenchido_e_tamanho_minimo_nao_respeitado()
        {

            //Arrange
            var sut = new Funcionario();
            var context = new ValidationContext(sut) { MemberName = "NomeFuncionario" };
            var results = new List<ValidationResult>();

            //Act
            var resultado = Validator.TryValidateProperty("Adolfo da", context, results);

            //Assert
            Assert.IsFalse(resultado);

        }
    }
}

using Domain.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainTests.TestesUnitario.Entidades
{
    [TestClass]
    public class EmpresaTest
    {

        [TestMethod]
        public void Retorna_verdadeiro_se_length_cnpj_for_igual_ou_menor_18()
        {
            //Arrange
            var sut = new Empresa();
            var context = new ValidationContext(sut) { MemberName = "CNPJ" };
            var results = new List<ValidationResult>();

            //Act
            var resultado = Validator.TryValidateProperty("123456789101234567", context, results);

            //Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void Retorna_falso_se_length_cnpj_for_maior_que_18()
        {
            //Arrange
            var sut = new Empresa();
            var context = new ValidationContext(sut) { MemberName = "CNPJ" };
            var results = new List<ValidationResult>();

            //Act
            var resultado = Validator.TryValidateProperty("1234567891012344567", context, results);

            //Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void Retorna_verdadeiro_se_length_razaoSocial_for_igual_ou_menor_70()
        {
            //Arrange
            var sut = new Empresa();
            var context = new ValidationContext(sut) { MemberName = "RazaoSocial" };
            var results = new List<ValidationResult>();
            var razaoSocial = "lorem ipsumlorem ipsumlorem ipsumlorem ipsumlorem ipsumlorem ipsumlo";

            //Act
            var resultado = Validator.TryValidateProperty(razaoSocial, context, results);

            //Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void Retorna_falso_se_length_razaoSocial_for_maior_que_70()
        {
            //Arrange
            var sut = new Empresa();
            var context = new ValidationContext(sut) { MemberName = "RazaoSocial" };
            var results = new List<ValidationResult>();
            var razaoSocial = "lorem ipsumlorem ipsumlorem ipsumaloreme ipsumlorem ipsuamlorem ipsumlo";

            //Act
            var resultado = Validator.TryValidateProperty(razaoSocial, context, results);

            //Assert
            Assert.IsFalse(resultado);
        }


        [TestMethod]
        public void Retorna_verdadeiro_se_length_nomeFantasia_for_igual_ou_menor_70()
        {
            //Arrange
            var sut = new Empresa();
            var context = new ValidationContext(sut) { MemberName = "NomeFantasia" };
            var results = new List<ValidationResult>();
            var nomeFantasia = "lorem ipsumlorem ipsumlorem ipsumlorem ipsumlorem ipsumlorem ipsumlo";

            //Act
            var resultado = Validator.TryValidateProperty(nomeFantasia, context, results);

            //Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void Retorna_falso_se_length_nomeFantasia_for_maior_que_70()
        {
            //Arrange
            var sut = new Empresa();
            var context = new ValidationContext(sut) { MemberName = "NomeFantasia" };
            var results = new List<ValidationResult>();
            var nomeFantasia = "lorem ipsumlorem ipsumlorem ipsumloremaea ipsumlorem ipsumlorem ipsumlo";

            //Act
            var resultado = Validator.TryValidateProperty(nomeFantasia, context, results);

            //Assert
            Assert.IsFalse(resultado);
        }
    }
}

using Domain.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTests.TestesUnitario.Entidades
{
    [TestClass]
    public class PatrimonioTest
    {

        [TestMethod]
        public void Retorna_falso_se_campo_modelo_for_nulo()
        {

            //Arrange
            var sut = new Patrimonio();
            var context = new ValidationContext(sut) { MemberName = "Modelo" };
            var results = new List<ValidationResult>();

            //Act
            var resultado = Validator.TryValidateProperty(null, context, results);

            //Assert
            Assert.IsFalse(resultado);

        }

        [TestMethod]
        public void Retorna_verdadeiro_se_campo_modelo_nao_for_nulo()
        {

            //Arrange
            var sut = new Patrimonio();
            var context = new ValidationContext(sut) { MemberName = "Modelo" };
            var results = new List<ValidationResult>();

            //Act
            var resultado = Validator.TryValidateProperty("", context, results);

            //Assert
            Assert.IsTrue(resultado);

        }

        [TestMethod]
        public void Retorna_falso_se_campo_serviceTag_for_nulo()
        {

            //Arrange
            var sut = new Patrimonio();
            var context = new ValidationContext(sut) { MemberName = "ServiceTag" };
            var results = new List<ValidationResult>();

            //Act
            var resultado = Validator.TryValidateProperty(null, context, results);

            //Assert
            Assert.IsFalse(resultado);

        }

        [TestMethod]
        public void Retorna_verdadeiro_se_campo_serviceTag_nao_for_nulo_e_ter_caracteres_minimo()
        {

            //Arrange
            var sut = new Patrimonio();
            var context = new ValidationContext(sut) { MemberName = "ServiceTag" };
            var results = new List<ValidationResult>();

            //Act
            var resultado = Validator.TryValidateProperty("1236", context, results);

            //Assert
            Assert.IsTrue(resultado);

        }

        [TestMethod]
        public void Retorna_falso_se_campo_serviceTag_nao_for_nulo_e_ter_caracteres_maximo_extrapolado()
        {

            //Arrange
            var sut = new Patrimonio();
            var context = new ValidationContext(sut) { MemberName = "ServiceTag" };
            var results = new List<ValidationResult>();

            //Act
            var resultado = Validator.TryValidateProperty("lorem ipsum lorem lor", context, results);

            //Assert
            Assert.IsFalse(resultado);

        }
    }
}

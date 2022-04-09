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
    public class FabricanteTest
    {
        [TestMethod]
        public void Retorna_falso_se_tamanho_minimo_nao_preenchido_do_campo_nomeFabricante()
        {

            //Arrange
            var sut = new Fabricante();
            var context = new ValidationContext(sut) { MemberName = "NomeFabricante" };
            var results = new List<ValidationResult>();

            //Act
            var resultado = Validator.TryValidateProperty("equ", context, results);

            //Assert
            Assert.IsFalse(resultado);

        }

        [TestMethod]
        public void Retorna_falso_se_tamanho_maximo_estrapolar_no_campo_nomeFabricante()
        {

            //Arrange
            var sut = new Fabricante();
            var context = new ValidationContext(sut) { MemberName = "NomeFabricante" };
            var results = new List<ValidationResult>();

            //Act
            var resultado = Validator.TryValidateProperty("lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem  ipsuma", context, results);

            //Assert
            Assert.IsFalse(resultado);

        }
    }
}

using Domain.Entidades;
using Domain.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainTests.TestesUnitario.Helpers
{
    [TestClass()]
    public class HTTPStatusTests
    {
        [TestMethod()]
        public void Retorna_status_204_se_classe_for_nula()
        {
            //Arrange & Act
            var sut = HTTPStatusHelper.RetornaStatus(null);

            //Assert
            Assert.AreEqual(204, sut);
        }

        [TestMethod()]
        public void Retorna_status_200_se_classe_nao_for_nula()
        {
            //Arrange & Act
            var sut = HTTPStatusHelper.RetornaStatus(new Patrimonio());

            //Assert
            Assert.AreEqual(200, sut);
        }
    }
}
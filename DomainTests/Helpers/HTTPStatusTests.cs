using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Helpers.Tests
{
    [TestClass()]
    public class HTTPStatusTests
    {
        [TestMethod()]
        public void Retorna_status_204_se_classe_for_nula()
        {
            //Arrange & Act
            var sut = HTTPStatus.RetornaStatus(null);

            //Assert
            Assert.AreEqual(204, sut);
        }
    }
}
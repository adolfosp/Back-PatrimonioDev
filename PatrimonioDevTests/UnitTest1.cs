using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using PatrimonioDev;
using PatrimonioDev.Controllers;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Xunit;

namespace PatrimonioDevTests
{
    public class UnitTest1
    {
        private readonly CategoriaController _controller;

        public UnitTest1()
        {
            _controller = new CategoriaController();

        }

        [Theory]
        [InlineData("GET")]
        public async Task TestMethod1(string method)
        {
            var request = _controller.ObterTodasCategorias();


            Assert.IsType<IActionResult>(request as IActionResult);

        }
    }
}

using Aplicacao.Features.CategoriaFeature.Queries;
using Aplicacao.Interfaces.Persistence;
using AutoFixture;
using DomainTests.TestesIntegracao.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PatrimonioDev.Controllers;
using System.Threading;
using static Aplicacao.Features.CategoriaFeature.Queries.ObterTodasCategorias;

namespace DomainTests.t
{
    [TestClass]
    public class CategoriaControllerTest
    {
        private Mock<IMediator> _service;
        private readonly ICategoriaPersistence _categoria;

        public CategoriaControllerTest()
        {
            _service = new Mock<IMediator>();
            _categoria = new CategoriaRepositoryFake();

    }

    [TestMethod]
        public void Retorna_status_code_200_caso_haja_informacao()
        {

            //Arrange
            var categoriaHandler = new ObterTodasCategoriasHandler(_categoria);
            var fixture = new Fixture();

            var handlerMoq = fixture.Create<ObterTodasCategorias>();
            _service.Setup(m => m.Send(It.IsAny<ObterTodasCategorias>(), It.IsAny<CancellationToken>())).
               Returns(async (ObterTodasCategorias q, CancellationToken token) => await categoriaHandler.Handle(handlerMoq, token));

            var sut = new CategoriaController();
            sut._mediator = _service.Object;

            //Act
            var actionResult = sut.ObterTodasCategorias();
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);
        }
    }
}

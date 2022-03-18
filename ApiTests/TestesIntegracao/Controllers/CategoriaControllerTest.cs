using Aplicacao.Features.CategoriaFeature.Commands;
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
using static Aplicacao.Features.CategoriaFeature.Commands.AtualizarCategoriaCommand;
using static Aplicacao.Features.CategoriaFeature.Commands.CriarCategoriaCommand;
using static Aplicacao.Features.CategoriaFeature.Commands.DeletarCategoriaCommand;
using static Aplicacao.Features.CategoriaFeature.Queries.ObterApenasUmaCategoria;
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

        [TestMethod]
        public void Retorna_status_code_200_caso_grave_informacao()
        {

            //Arrange
            var categoriaHandler = new CriarEquipamentoCommandHandler(_categoria);
            var fixture = new Fixture();

            var handlerMoq = fixture.Create<CriarCategoriaCommand>();
            _service.Setup(m => m.Send(It.IsAny<CriarCategoriaCommand>(), It.IsAny<CancellationToken>())).
             Returns(async (CriarCategoriaCommand q, CancellationToken token) => await categoriaHandler.Handle(handlerMoq, token));

            var sut = new CategoriaController();
            sut._mediator = _service.Object;

            //Act
            var actionResult = sut.CriarCategoria(new CriarCategoriaCommand() { Categoria = new Aplicacao.Dtos.CategoriaDto()});
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void Retorna_status_code_200_caso_haja_delecao()
        {

            //Arrange
            var categoriaHandler = new DeletarCategoriaCommandHandler(_categoria);
            var fixture = new Fixture();

            var handlerMoq = fixture.Create<DeletarCategoriaCommand>();
            _service.Setup(m => m.Send(It.IsAny<DeletarCategoriaCommand>(), It.IsAny<CancellationToken>())).
             Returns(async (DeletarCategoriaCommand q, CancellationToken token) => await categoriaHandler.Handle(handlerMoq, token));

            var sut = new CategoriaController();
            sut._mediator = _service.Object;

            //Act
            var actionResult = sut.DeletarCategoria(1);
            var result = actionResult.Result as OkResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);
        }


        [TestMethod]
        public void Retorna_status_code_200_caso_haja_alteracao()
        {

            //Arrange
            var categoriaHandler = new AtualizarCategoriaCommandHandler(_categoria);
            var fixture = new Fixture();

            var handlerMoq = fixture.Create<AtualizarCategoriaCommand>();
            _service.Setup(m => m.Send(It.IsAny<AtualizarCategoriaCommand>(), It.IsAny<CancellationToken>())).
             Returns(async (AtualizarCategoriaCommand q, CancellationToken token) => await categoriaHandler.Handle(handlerMoq, token));

            var sut = new CategoriaController();
            sut._mediator = _service.Object;

            //Act
            var actionResult = sut.AtualizarCategoria(1, new AtualizarCategoriaCommand() { Categoria = new Domain.Entidades.CategoriaEquipamento() });
            var result = actionResult.Result as OkResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void Retorna_status_code_500_caso_haja_falha_no_processo()
        {

            //Arrange
            var categoriaHandler = new AtualizarCategoriaCommandHandler(_categoria);
            var fixture = new Fixture();

            var handlerMoq = fixture.Create<AtualizarCategoriaCommand>();
            _service.Setup(m => m.Send(It.IsAny<AtualizarCategoriaCommand>(), It.IsAny<CancellationToken>())).
             Returns(async (AtualizarCategoriaCommand q, CancellationToken token) => await categoriaHandler.Handle(handlerMoq, token));

            var sut = new CategoriaController();
            sut._mediator = _service.Object;

            //Act
            var actionResult = sut.AtualizarCategoria(1, new AtualizarCategoriaCommand() { });
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(500, result.StatusCode);
        }

        [TestMethod]
        public void Retorna_status_code_200_caso_haja_registro()
        {

            //Arrange
            var categoriaHandler = new ObterApenasUmaCategoriaHandler(_categoria);
            var fixture = new Fixture();

            var handlerMoq = fixture.Create<ObterApenasUmaCategoria>();
            _service.Setup(m => m.Send(It.IsAny<ObterApenasUmaCategoria>(), It.IsAny<CancellationToken>())).
             Returns(async (ObterApenasUmaCategoria q, CancellationToken token) => await categoriaHandler.Handle(handlerMoq, token));

            var sut = new CategoriaController();
            sut._mediator = _service.Object;

            //Act
            var actionResult = sut.ObterApenasUm(1);
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);
        }
    }
}

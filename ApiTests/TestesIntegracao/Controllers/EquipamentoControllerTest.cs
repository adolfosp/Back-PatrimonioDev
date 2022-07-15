using ApiTests.TestesIntegracao.Repositories;
using Aplicacao.Features.EquipamentoFeature.Commands;
using Aplicacao.Features.EquipamentoFeature.Queries;
using AutoFixture;
using Domain.Interfaces.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PatrimonioDev.Controllers;
using System.Threading;
using static Aplicacao.Features.EquipamentoFeature.Commands.AtualizarEquipamentoCommand;
using static Aplicacao.Features.EquipamentoFeature.Commands.CriarEquipamentoCommand;
using static Aplicacao.Features.EquipamentoFeature.Commands.DeletarEquipamentoCommand;
using static Aplicacao.Features.EquipamentoFeature.Queries.ObterApenasUmEquipamento;
using static Aplicacao.Features.EquipamentoFeature.Queries.ObterTodosEquipamento;

namespace ApiTests.TestesIntegracao.Controllers
{
    [TestClass]
    public class EquipamentoControllerTest
    {
        private Mock<IMediator> _service;
        private readonly IEquipamentoPersistence _equipamento;

        public EquipamentoControllerTest()
        {
            _service = new Mock<IMediator>();
            _equipamento = new EquipamentoRepositoryFake();

        }

        [TestMethod]
        public void Retorna_status_code_200_caso_haja_informacao()
        {

            //Arrange
            var equipamentoHandler = new ObterTodosEquipamentoHandler(_equipamento);
            var fixture = new Fixture();

            var handlerMoq = fixture.Create<ObterTodosEquipamento>();
            _service.Setup(m => m.Send(It.IsAny<ObterTodosEquipamento>(), It.IsAny<CancellationToken>())).
               Returns(async (ObterTodosEquipamento q, CancellationToken token) => await equipamentoHandler.Handle(handlerMoq, token));

            var sut = new EquipamentoController();
            sut._mediator = _service.Object;

            //Act
            var actionResult = sut.ListarTodosEquipamento();
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void Retorna_status_code_200_caso_informacao_for_excluida()
        {

            //Arrange
            var equipamentoHandler = new DeletarEquipamentoCommandHandler(_equipamento);
            var fixture = new Fixture();

            var handlerMoq = fixture.Create<DeletarEquipamentoCommand>();
            _service.Setup(m => m.Send(It.IsAny<DeletarEquipamentoCommand>(), It.IsAny<CancellationToken>())).
               Returns(async (DeletarEquipamentoCommand q, CancellationToken token) => await equipamentoHandler.Handle(handlerMoq, token));

            var sut = new EquipamentoController();
            sut._mediator = _service.Object;

            //Act
            var actionResult = sut.DeletarEquipamento(1);
            var result = actionResult.Result as OkResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void Retorna_status_code_200_caso_retorne_um_elemento()
        {

            //Arrange
            var equipamentoHandler = new ObterApenasUmEquipamentoHandler(_equipamento);
            var fixture = new Fixture();

            var handlerMoq = fixture.Create<ObterApenasUmEquipamento>();
            _service.Setup(m => m.Send(It.IsAny<ObterApenasUmEquipamento>(), It.IsAny<CancellationToken>())).
               Returns(async (ObterApenasUmEquipamento q, CancellationToken token) => await equipamentoHandler.Handle(handlerMoq, token));

            var sut = new EquipamentoController();
            sut._mediator = _service.Object;

            //Act
            var actionResult = sut.ListarEquipamentoPorId(1);
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void Retorna_status_code_200_caso_atualize_equipamento()
        {

            //Arrange
            var equipamentoHandler = new AtualizarEquipamentoCommandHandler(_equipamento);
            var fixture = new Fixture();

            var handlerMoq = fixture.Create<AtualizarEquipamentoCommand>();
            _service.Setup(m => m.Send(It.IsAny<AtualizarEquipamentoCommand>(), It.IsAny<CancellationToken>())).
               Returns(async (AtualizarEquipamentoCommand q, CancellationToken token) => await equipamentoHandler.Handle(handlerMoq, token));

            var sut = new EquipamentoController();
            sut._mediator = _service.Object;

            //Act
            var actionResult = sut.AtualizarEquipamento(1, new AtualizarEquipamentoCommand());
            var result = actionResult.Result as OkResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void Retorna_status_code_200_caso_cadastre_equipamento()
        {

            //Arrange
            var equipamentoHandler = new CriarEquipamentoCommandHandler(_equipamento);
            var fixture = new Fixture();

            var handlerMoq = fixture.Create<CriarEquipamentoCommand>();
            _service.Setup(m => m.Send(It.IsAny<CriarEquipamentoCommand>(), It.IsAny<CancellationToken>())).
               Returns(async (CriarEquipamentoCommand q, CancellationToken token) => await equipamentoHandler.Handle(handlerMoq, token));

            var sut = new EquipamentoController();
            sut._mediator = _service.Object;

            //Act
            var actionResult = sut.CriarEquipamento(new CriarEquipamentoCommand());
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);
        }
    }
}

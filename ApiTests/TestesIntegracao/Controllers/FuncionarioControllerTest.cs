using ApiTests.TestesIntegracao.Repositories;
using Aplicacao.Features.FuncionarioFeature.Commands;
using Aplicacao.Features.FuncionarioFeature.Queries;
using Aplicacao.Interfaces.Persistence;
using AutoFixture;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PatrimonioDev.Controllers;
using System.Threading;
using static Aplicacao.Features.FuncionarioFeature.Commands.AtualizarFuncionarioCommand;
using static Aplicacao.Features.FuncionarioFeature.Commands.CriarFuncionarioCommand;
using static Aplicacao.Features.FuncionarioFeature.Commands.DesativarFuncionarioCommand;
using static Aplicacao.Features.FuncionarioFeature.Queries.ObterFuncionarioPorId;
using static Aplicacao.Features.FuncionarioFeature.Queries.ObterTodosFuncionarios;

namespace ApiTests.TestesIntegracao.Controllers
{
    [TestClass]
    public class FuncionarioControllerTest
    {
        private Mock<IMediator> _service;
        private readonly IFuncionarioPersistence _funcionario;
        

        public FuncionarioControllerTest()
        {
            _service = new Mock<IMediator>();
            _funcionario = new FuncionarioRepositoryFake();

        }


        [TestMethod]
        public void Retorna_status_code_200_caso_haja_informacao()
        {
            //Arrange
            var funcionarioHandler = new ObterTodosFuncionariosHandler(_funcionario);
            var fixture = new Fixture();

            var handlerMoq = fixture.Create<ObterTodosFuncionarios>();
            _service.Setup(m => m.Send(It.IsAny<ObterTodosFuncionarios>(), It.IsAny<CancellationToken>())).
               Returns(async (ObterTodosFuncionarios q, CancellationToken token) => await funcionarioHandler.Handle(handlerMoq, token));

            var sut = new FuncionarioController();
            sut._mediator = _service.Object;

            //Act
            var actionResult = sut.ListarTodosFuncionario();
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void Retorna_status_code_500_caso_haja_erro_ao_chamar_classe_obterTodosFuncionarios_com_context_nulo()
        {
            //Arrange
            var funcionarioHandler = new ObterTodosFuncionariosHandler(null);
            var fixture = new Fixture();

            var handlerMoq = fixture.Create<ObterTodosFuncionarios>();
            _service.Setup(m => m.Send(It.IsAny<ObterTodosFuncionarios>(), It.IsAny<CancellationToken>())).
               Returns(async (ObterTodosFuncionarios q, CancellationToken token) => await funcionarioHandler.Handle(handlerMoq, token));

            var sut = new FuncionarioController();
            sut._mediator = _service.Object;

            //Act & Assert
            Assert.ThrowsExceptionAsync<System.NullReferenceException>(() => sut.ListarTodosFuncionario());
        }

        [TestMethod]
        public void Retorna_status_code_200_caso_haja_informacao_por_busca_ID()
        {
            //Arrange
            var funcionarioHandler = new ObterFuncionarioPorIdHandler(_funcionario);
            var fixture = new Fixture();

            var handlerMoq = fixture.Create<ObterFuncionarioPorId>();
            _service.Setup(m => m.Send(It.IsAny<ObterFuncionarioPorId>(), It.IsAny<CancellationToken>())).
               Returns(async (ObterFuncionarioPorId q, CancellationToken token) => await funcionarioHandler.Handle(handlerMoq, token));

            var sut = new FuncionarioController();
            sut._mediator = _service.Object;

            //Act
            var actionResult = sut.ListarFuncionarioPorId(1);
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void Retorna_status_code_500_caso_haja_erro_ao_chamar_listarFuncionarioPorId_com_context_nulo()
        {
            //Arrange
            var funcionarioHandler = new ObterFuncionarioPorIdHandler(null);
            var fixture = new Fixture();

            var handlerMoq = fixture.Create<ObterFuncionarioPorId>();
            _service.Setup(m => m.Send(It.IsAny<ObterFuncionarioPorId>(), It.IsAny<CancellationToken>())).
               Returns(async (ObterFuncionarioPorId q, CancellationToken token) => await funcionarioHandler.Handle(handlerMoq, token));

            var sut = new FuncionarioController();
            sut._mediator = _service.Object;

            //Act & Assert
            Assert.ThrowsExceptionAsync<System.NullReferenceException>(() => sut.ListarFuncionarioPorId(1));

        }

        [TestMethod]
        public void Retorna_status_code_500_caso_haja_erro_ao_chamar_criarFuncionario_com_context_nulo()
        {
            //Arrange
            var funcionarioHandler = new CriarFuncionarioCommandHandler(null);
            var fixture = new Fixture();

            var handlerMoq = fixture.Create<CriarFuncionarioCommand>();
            _service.Setup(m => m.Send(It.IsAny<CriarFuncionarioCommand>(), It.IsAny<CancellationToken>())).
               Returns(async (CriarFuncionarioCommand q, CancellationToken token) => await funcionarioHandler.Handle(handlerMoq, token));

            var sut = new FuncionarioController();
            sut._mediator = _service.Object;

            //Act & Assert
            Assert.ThrowsExceptionAsync<System.NullReferenceException>(() => sut.CriarFuncionario(handlerMoq));

        }

        [TestMethod]
        public void Retorna_status_code_200_caso_grave_informacao()
        {
            //Arrange
            var funcionarioHandler = new CriarFuncionarioCommandHandler(_funcionario);
            var fixture = new Fixture();

            var handlerMoq = fixture.Create<CriarFuncionarioCommand>();
            _service.Setup(m => m.Send(It.IsAny<CriarFuncionarioCommand>(), It.IsAny<CancellationToken>())).
               Returns(async (CriarFuncionarioCommand q, CancellationToken token) => await funcionarioHandler.Handle(handlerMoq, token));

            var sut = new FuncionarioController();
            sut._mediator = _service.Object;

            //Act
            var actionResult = sut.CriarFuncionario(handlerMoq);
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);

        }

        [TestMethod]
        public void Retorna_status_code_200_caso_atualize_informacao()
        {
            //Arrange
            var funcionarioHandler = new AtualizarFuncionarioCommandHandler(_funcionario);
            var fixture = new Fixture();

            var handlerMoq = fixture.Create<AtualizarFuncionarioCommand>();
            _service.Setup(m => m.Send(It.IsAny<AtualizarFuncionarioCommand>(), It.IsAny<CancellationToken>())).
               Returns(async (AtualizarFuncionarioCommand q, CancellationToken token) => await funcionarioHandler.Handle(handlerMoq, token));

            var sut = new FuncionarioController();
            sut._mediator = _service.Object;

            //Act
            var actionResult = sut.AtualizarFuncionario(3,handlerMoq);
            var result = actionResult.Result as OkResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);

        }

        [TestMethod]
        public void Retorna_status_code_500_caso_haja_erro_ao_chamar_atualizarFuncionarioCommand_com_context_nulo()
        {
            //Arrange
            var funcionarioHandler = new AtualizarFuncionarioCommandHandler(null);
            var fixture = new Fixture();

            var handlerMoq = fixture.Create<AtualizarFuncionarioCommand>();
            _service.Setup(m => m.Send(It.IsAny<AtualizarFuncionarioCommand>(), It.IsAny<CancellationToken>())).
               Returns(async (AtualizarFuncionarioCommand q, CancellationToken token) => await funcionarioHandler.Handle(handlerMoq, token));

            var sut = new FuncionarioController();
            sut._mediator = _service.Object;

            //Act & Assert
            Assert.ThrowsExceptionAsync<System.NullReferenceException>(() => sut.AtualizarFuncionario(2, handlerMoq));
        }

        [TestMethod]
        public void Retorna_status_code_200_caso_haja_delecao()
        {
            //Arrange
            var funcionarioHandler = new DesativarFuncionarioCommandHandler(_funcionario);
            var fixture = new Fixture();

            var handlerMoq = fixture.Create<DesativarFuncionarioCommand>();
            _service.Setup(m => m.Send(It.IsAny<DesativarFuncionarioCommand>(), It.IsAny<CancellationToken>())).
               Returns(async (DesativarFuncionarioCommand q, CancellationToken token) => await funcionarioHandler.Handle(handlerMoq, token));

            var sut = new FuncionarioController();
            sut._mediator = _service.Object;

            //Act
            var actionResult = sut.DesativarFuncionario(3);
            var result = actionResult.Result as OkResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);

        }

        [TestMethod]
        public void Retorna_status_code_500_caso_haja_erro_ao_chamar_desativarFuncionarioComman_com_context_nulo()
        {
            //Arrange
            var funcionarioHandler = new DesativarFuncionarioCommandHandler(null);
            var fixture = new Fixture();

            var handlerMoq = fixture.Create<DesativarFuncionarioCommand>();
            _service.Setup(m => m.Send(It.IsAny<DesativarFuncionarioCommand>(), It.IsAny<CancellationToken>())).
               Returns(async (DesativarFuncionarioCommand q, CancellationToken token) => await funcionarioHandler.Handle(handlerMoq, token));

            var sut = new FuncionarioController();
            sut._mediator = _service.Object;

            //Act & Assert
            Assert.ThrowsExceptionAsync<System.NullReferenceException>(() => sut.DesativarFuncionario(3));

        }
    }
}

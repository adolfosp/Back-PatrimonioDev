using Aplicacao.Features.PerfilUsuarioFeature.Commands;
using Aplicacao.Features.PerfilUsuarioFeature.Queries;
using AutoFixture;
using Domain.Interfaces.Persistence;
using DomainTests.TestesIntegracao.Repositories;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PatrimonioDev.Controllers;
using System.Threading;
using static Aplicacao.Features.PerfilUsuarioFeature.Commands.AtualizarPerfilCommand;
using static Aplicacao.Features.PerfilUsuarioFeature.Queries.ObterPerfilUsuario;

namespace DomainTests.TestesIntegracao.Controllers
{

    [TestClass]
    public class PerfilUsuarioControllerTest
    {
        private Mock<IMediator> _service;
        private readonly IPerfilUsuarioPersistence _perfil;

        public PerfilUsuarioControllerTest()
        {
            _service = new Mock<IMediator>();
            _perfil = new PerfilUsuarioRepositoryFake();
        }

        [TestMethod]
        public void Retorna_status_code_200_caso_retorne_classe()
        {

            //Arrange
            var perfilHandler = new ObterPerfilUsuarioHandler(_perfil);
            var fixture = new Fixture();

            var handlerMoq = fixture.Create<ObterPerfilUsuario>();
            _service.Setup(m => m.Send(It.IsAny<ObterPerfilUsuario>(), It.IsAny<CancellationToken>())).
               Returns(async (ObterPerfilUsuario q, CancellationToken token) => await perfilHandler.Handle(handlerMoq, token));

            var mockEnvironment = new Mock<IWebHostEnvironment>();
            mockEnvironment
                .Setup(m => m.EnvironmentName)
                .Returns("Hosting:UnitTestEnvironment");

            var sut = new PerfilUsuarioController(mockEnvironment.Object);
            sut._mediator = _service.Object;

            //Act
            var actionResult = sut.ObterInformacoesPerfil(1);
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void Retorna_status_code_404_para_usuario_nao_encontrado()
        {

            //Arrange
            var perfilHandler = new AtualizarPerfilCommandHandler(_perfil);
            var fixture = new Fixture();

            var handlerMoq = fixture.Create<AtualizarPerfilCommand>();
            _service.Setup(m => m.Send(It.IsAny<AtualizarPerfilCommand>(), It.IsAny<CancellationToken>())).
               Returns(async (AtualizarPerfilCommand q, CancellationToken token) => await perfilHandler.Handle(handlerMoq, token));

            var mockEnvironment = new Mock<IWebHostEnvironment>();
            mockEnvironment
                .Setup(m => m.EnvironmentName)
                .Returns("Hosting:UnitTestEnvironment");

            var sut = new PerfilUsuarioController(mockEnvironment.Object);
            sut._mediator = _service.Object;

            //Act
            var actionResult = sut.AlterarPerfilUsuario(null);
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(404, result.StatusCode);
        }
    }
}

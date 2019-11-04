using AtivaInvestimentos.API.Controllers;
using AtivaInvestimentos.Domain.DTOs;
using AtivaInvestimentos.Domain.Entities.Mapeamento;
using AtivaInvestimentos.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AtivaInvestimentos.Tests
{
    public class FundosTest
    {
        [Fact]
        public async void ListarFundos_DeveTrazerTodosOsFundosDoMock()
        {
            FundoController controller = CriarMockFundoController();

            var result = await controller.Get();
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<List<Fundo>>(viewResult.Value);

            Assert.Equal(2, model.Count());
        }

        #region Metodos Comuns
        private List<Fundo> GetListaFundosMock()
        {
            var sessions = new List<Fundo>();
            sessions.Add(new Fundo()
            {
                Id = Guid.NewGuid(),
                CNPJFundo = "68406170000104",
                InvestimentoMinimo = 10000,
                NomeFundo = "Fundo Alaska Teste"
            });

            sessions.Add(new Fundo()
            {
                Id = Guid.NewGuid(),
                CNPJFundo = "83762855000187",
                InvestimentoMinimo = 2500,
                NomeFundo = "ARGUCIA INCOME FIA"
            });

            return sessions;
        }
        private FundoController CriarMockFundoController()
        {
            var mockRepo = new Mock<IFundoService>();
            mockRepo.Setup(repo => repo.ListarFundos()).Returns(GetListaFundosMock());
            return new FundoController(mockRepo.Object);
        }
        #endregion
    }
}

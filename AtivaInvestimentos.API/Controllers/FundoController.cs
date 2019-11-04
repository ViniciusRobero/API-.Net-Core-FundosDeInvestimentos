using System;
using System.Threading.Tasks;
using AtivaInvestimentos.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AtivaInvestimentos.Domain.Entities.Mapeamento;
using AtivaInvestimentos.Domain.DTOs;
using System.Collections.Generic;

namespace AtivaInvestimentos.API.Controllers
{
    [ApiController, Route("fundo")]
    public class FundoController : ControllerBase
    {
        private readonly IFundoService _fundoService;
        public FundoController(IFundoService fundoService)
        {
            _fundoService = fundoService;
        }

        /// <summary>
        ///    Lista todos os fundos cadastrados.
        /// </summary>
        /// <response code="200">Retorna todos os fundos cadastrados ou retorna vazio caso não possua fundos na base. </response>
        /// /// <response code="400">Caso ocorra algum erro no processamento, retorna mensagem de erro. </response> 
        [HttpGet]
        [ProducesResponseType(typeof(List<Fundo>),200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(_fundoService.ListarFundos());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///   Aplica o dinheiro do cliente em um fundo de investimento específico.
        /// </summary>
        /// <param name="movimentacao">No momento da aplicação, o sistema irá criar uma movimentação para o cliente e irá aplicar o dinheiro no fundo escolhido.</param>
        /// <response code="200"> Retorna true, aplicação feita com sucesso. </response>
        /// <response code="400">Caso ocorra algum erro na aplicação, retorna mensagem de erro. </response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [HttpPost, Route("aplicar")]
        public async Task<IActionResult> Aplicar([FromBody]MovimentacaoRequestDTO movimentacao)
        {
            try
            {
                return Ok(_fundoService.Aplicar(movimentacao));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///   Resgate o dinheiro do cliente que esteja aplicado em um fundo de investimento específico.
        /// </summary>
        /// <param name="movimentacao">No momento do resgate, o sistema irá criar uma movimentação para o cliente e irá retirar o dinheiro do cliente do fundo escolhido.</param>
        /// <response code="200"> Retorna true, resgate foi feito com sucesso. </response>
        /// <response code="400">Caso ocorra algum erro no resgate, retorna mensagem de erro. </response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [HttpPost, Route("resgatar")]
        public async Task<IActionResult> Resgatar([FromBody]MovimentacaoRequestDTO movimentacao)
        {
            try
            {
                return Ok(_fundoService.Resgatar(movimentacao));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
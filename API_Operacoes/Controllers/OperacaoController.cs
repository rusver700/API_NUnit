using API_Operacoes.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace API_Operacoes.Controllers
{
    [ExcludeFromCodeCoverage]
    [Route("api/[controller]")]
    [ApiController]
    public class OperacaoController : ControllerBase
    {
        private readonly IServico _servico;
        private readonly IOpcoesSwitch _opcoesSwitch;

        public OperacaoController(IServico servico, IOpcoesSwitch opcoesSwitch)
        {
            _servico = servico;
            _opcoesSwitch = opcoesSwitch;
        }

        [HttpGet("GetOpcoes")]
        public IActionResult GetOpcoes()
        {
            var result = "1 = Subtrair \n2 = Somar \n3 = Multiplicar \n4 = Dividir \n5 = Média ";

            return Ok(result);
        }

        [HttpGet("OpcaoSwitchCase")]
        public IActionResult OpcaoSwitchCase(string opcao, double n1, double n2)
        {
            if (opcao == "1" || opcao == "2" || opcao == "3" || (opcao == "4" && n2 != 0) || opcao == "5")
            {
                var result = _opcoesSwitch.Opcao(opcao, n1, n2);

                return Ok(result);

            }
            else if (opcao == "4" && n2 == 0)
            {
                return BadRequest($"Não é possivel dividir por {n2}");
            }

            return NotFound("Solicitação Invalida");
        }

        [HttpGet("Somar")]
        public IActionResult Somar(double n1, double n2)
        {
            var result = _servico.Somar(n1, n2);
            return Ok(result);
        }

        [HttpGet("Subtrair")]
        public IActionResult Subtrair(double n1, double n2)
        {
            var result = _servico.Subtrair(n1, n2);
            return Ok(result);
        }
        [HttpGet("Multiplicar")]
        public IActionResult Multiplicar(double n1, double n2)
        {
            var result = _servico.Multiplicar(n1, n2);
            return Ok(result);
        }

        [HttpGet("Media")]
        public IActionResult Media(double n1, double n2)
        {
            var result = _servico.Media(n1, n2);
            return Ok(result);
        }

        [HttpGet("Dividir")]
        public IActionResult Dividir(double n1, double n2)
        {
            if (n2 != 0)
            {
                var result = _servico.Dividir(n1, n2);
                return Ok(result);
            }

            return BadRequest($"Não é possivel dividir por {n2}");
        }
    }
}

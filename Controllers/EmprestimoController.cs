using BibliotecaApi.Models;
using BibliotecaApi.Services.Emprestimo;
using Microsoft.AspNetCore.Mvc;


namespace BibliotecaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmprestimoController : ControllerBase
    {
        private readonly IEmprestimoService _emprestimoService;

        public EmprestimoController(IEmprestimoService emprestimoService)
        {
            _emprestimoService = emprestimoService;
        }

        [HttpGet("obterTodosOsEmprestimos")]
        public async Task<ActionResult<IEnumerable<EmprestismoDeLivros>>> ObterTodosEmprestimos()
        {
            return Ok(await _emprestimoService.ObterTodosEmprestimos());
        }

        [HttpGet("obterEmprestimosPorUsuario/{idUsuario}")]
        public async Task<ActionResult<IEnumerable<EmprestismoDeLivros>>> ObterEmprestimosPorUsuario(int IdUsuario)
        {
            return Ok(await _emprestimoService.ObterEmprestimosPorUsuario(IdUsuario));
        }

        [HttpPost("realizarEmprestimo")]
        public async Task<ActionResult<EmprestismoDeLivros>> RealizarEmprestimo(int IdLivro, int IdUsuario)
        {
            var emprestimo = await _emprestimoService.RealizarEmprestimo(IdLivro, IdUsuario);

            if (emprestimo == null)
                return BadRequest();

            return CreatedAtAction(nameof(ObterEmprestimosPorUsuario), new { IdUsuario = emprestimo.IdUsuario }, emprestimo);
        }

        [HttpPut("realizarDevolucao/{IdTransacao}")]
        public async Task<IActionResult> RealizarDevolucao(int IdTransacao)
        {
            var sucesso = await _emprestimoService.RealizarDevolucao(IdTransacao);

            if (!sucesso)
                return BadRequest();

            return NoContent();
        }
    }

}
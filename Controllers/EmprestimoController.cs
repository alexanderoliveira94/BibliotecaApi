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
        public async Task<ActionResult<IEnumerable<EmprestismoDeLivros>>> ObterEmprestimosPorUsuario(int idUsuario)
        {
            return Ok(await _emprestimoService.ObterEmprestimosPorUsuario(idUsuario));
        }

        [HttpPost("realizarEmprestimo")]
        public async Task<ActionResult<EmprestismoDeLivros>> RealizarEmprestimo(int idLivro, int idUsuario)
        {
            var emprestimo = await _emprestimoService.RealizarEmprestimo(idLivro, idUsuario);

            if (emprestimo == null)
                return BadRequest();

            return CreatedAtAction(nameof(ObterEmprestimosPorUsuario), new { idUsuario = emprestimo.IdUsuario }, emprestimo);
        }

        [HttpPut("realizarDevolucao/{idTransacao}")]
        public async Task<IActionResult> RealizarDevolucao(int idTransacao)
        {
            var sucesso = await _emprestimoService.RealizarDevolucao(idTransacao);

            if (!sucesso)
                return BadRequest();

            return NoContent();
        }
    }

}
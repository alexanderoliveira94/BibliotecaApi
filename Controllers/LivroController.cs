using BibliotecaApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace BibliotecaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly ILivroService _livroService;

        public LivrosController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        [HttpGet("obterTodosOsLivros")]
        public async Task<ActionResult<IEnumerable<Livro>>> ObterTodosLivros()
        {
            return Ok(await _livroService.ObterTodosLivros());
        }

        [HttpGet("obterLivroPorid")]
        public async Task<ActionResult<Livro>> ObterLivroPorId(int id)
        {
            var livro = await _livroService.ObterLivroPorId(id);

            if (livro == null)
                return NotFound();

            return livro;
        }

        [HttpGet("buscarLivros")]
        public async Task<ActionResult<IEnumerable<Livro>>> BuscarLivros(string termoBusca)
        {
            var livrosEncontrados = await _livroService.BuscarLivros(termoBusca);

            if (!livrosEncontrados.Any())
                return NotFound();

            return Ok(livrosEncontrados);
        }

        [HttpPost("adicionarLivro")]
        public async Task<ActionResult<Livro>> AdicionarLivro(Livro livro)
        {
            var novoLivro = await _livroService.AdicionarLivro(livro);
            return CreatedAtAction(nameof(ObterLivroPorId), new { id = novoLivro.IdLivro }, novoLivro);
        }

        [HttpPut("atualizarLivroPorId/{id}")]
        public async Task<IActionResult> AtualizarLivro(int id, Livro livroAtualizado)
        {
            var livro = await _livroService.ObterLivroPorId(id);

            if (livro == null)
                return NotFound();

            
            livro.Autor = livroAtualizado.Autor;
            livro.Categoria = livroAtualizado.Categoria;
            livro.Titulo = livroAtualizado.Titulo;

            var sucesso = await _livroService.AtualizarLivro(id, livro);

            if (!sucesso)
                return BadRequest();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarLivro(int id)
        {
            var sucesso = await _livroService.DeletarLivro(id);

            if (!sucesso)
                return NotFound();

            return NoContent();
        }
    }
}
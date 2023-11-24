using BibliotecaApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaApi.Controllers
{



    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("obterTodosUsuarios")]
        public async Task<ActionResult<IEnumerable<Usuario>>> ObterTodosUsuarios()
        {
            return Ok(await _usuarioService.ObterTodosUsuarios());
        }

        [HttpGet("obterUsuarioPorId/{id}")]
        public async Task<ActionResult<Usuario>> ObterUsuarioPorId(int id)
        {
            var usuario = await _usuarioService.ObterUsuarioPorId(id);

            if (usuario == null)
                return NotFound();

            return usuario;
        }

        [HttpPost("adicionarUsuario")]
        public async Task<ActionResult<Usuario>> AdicionarUsuario(Usuario usuario)
        {
            var novoUsuario = await _usuarioService.AdicionarUsuario(usuario);
            return CreatedAtAction(nameof(ObterUsuarioPorId), new { id = novoUsuario.IdUsuario }, novoUsuario);
        }

        [HttpPut("atualizarUsuario/{id}")]
        public async Task<IActionResult> AtualizarUsuario(int id, Usuario usuarioAtualizado)
        {
            var usuario = await _usuarioService.ObterUsuarioPorId(id);

            if (usuario == null)
                return NotFound();

            usuario.NomeUsuario = usuarioAtualizado.NomeUsuario;

            var sucesso = await _usuarioService.AtualizarUsuario(id, usuario);

            if (!sucesso)
                return BadRequest();

            return NoContent();
        }

        [HttpDelete("deletarUsuario/{id}")]
        public async Task<IActionResult> DeletarUsuario(int id)
        {
            var sucesso = await _usuarioService.DeletarUsuario(id);

            if (!sucesso)
                return NotFound();

            return NoContent();
        }
    }

}
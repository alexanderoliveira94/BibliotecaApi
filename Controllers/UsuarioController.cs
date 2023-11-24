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

        [HttpGet("obterUsuarioPorId/{IdUsuario}")]
        public async Task<ActionResult<Usuario>> ObterUsuarioPorId(int IdUsuario)
        {
            var usuario = await _usuarioService.ObterUsuarioPorId(IdUsuario);

            if (usuario == null)
                return NotFound();

            return usuario;
        }

        [HttpPost("adicionarUsuario")]
        public async Task<ActionResult<Usuario>> AdicionarUsuario(Usuario usuario)
        {
            var novoUsuario = await _usuarioService.AdicionarUsuario(usuario);
            return CreatedAtAction(nameof(ObterUsuarioPorId), new { IdUsuario = novoUsuario.IdUsuario }, novoUsuario);
        }

        [HttpPut("atualizarUsuario/{IdUsuario}")]
        public async Task<IActionResult> AtualizarUsuario(int IdUsuario, Usuario usuarioAtualizado)
        {
            var usuario = await _usuarioService.ObterUsuarioPorId(IdUsuario);

            if (usuario == null)
                return NotFound();

            usuario.NomeUsuario = usuarioAtualizado.NomeUsuario;

            var sucesso = await _usuarioService.AtualizarUsuario(IdUsuario, usuario);

            if (!sucesso)
                return BadRequest("O nome do usuário já esta cadastrado.");

            return NoContent();
        }


        [HttpDelete("{IdUsuario}")]
        public async Task<IActionResult> DeletarUsuario(int IdUsuario)
        {
            var sucesso = await _usuarioService.DeletarUsuario(IdUsuario);

            if (!sucesso)
                return NotFound();

            return NoContent();
        }
    }

}
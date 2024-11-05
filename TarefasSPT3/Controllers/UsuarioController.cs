// Controllers/UsuarioController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TarefasSPT3.Models;
using TarefasSPT3.Repositories.Interfaces;

namespace TarefasSPT3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Protege todos os endpoints deste controlador
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> BuscarTodosUsuarios()
        {
            var usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> BuscarPorId(int id)
        {
            var usuario = await _usuarioRepositorio.BuscarPorId(id);
            if (usuario == null)
            {
                return NotFound("Usuário não encontrado.");
            }
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Adicionar(Usuario usuario)
        {
            var novoUsuario = await _usuarioRepositorio.Adicionar(usuario);
            return CreatedAtAction(nameof(BuscarPorId), new { id = novoUsuario.Id }, novoUsuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> Atualizar(int id, Usuario usuario)
        {
            var usuarioAtualizado = await _usuarioRepositorio.Atualizar(usuario, id);
            if (usuarioAtualizado == null)
            {
                return NotFound("Usuário não encontrado.");
            }
            return Ok(usuarioAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Apagar(int id)
        {
            var apagado = await _usuarioRepositorio.Apagar(id);
            if (!apagado)
            {
                return NotFound("Usuário não encontrado.");
            }
            return NoContent();
        }
    }
}

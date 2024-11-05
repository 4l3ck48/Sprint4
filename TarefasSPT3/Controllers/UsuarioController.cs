using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TarefasSPT3.Models;

namespace TarefasSPT3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Usuario>> BuscarTodosUsuarios()
        {
            return Ok();
        }
    }
}

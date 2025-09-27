using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos;

namespace UsuariosApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    [HttpGet("cadastrar")]
    public IActionResult CadastrarUsuario([FromBody] CreateUsuarioDto usuario)
    {

        return Ok("Usuário cadastrado com sucesso!");
    }
}

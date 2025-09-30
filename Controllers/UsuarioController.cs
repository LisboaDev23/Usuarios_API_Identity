using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;
using UsuariosApi.Services.Interfaces;

namespace UsuariosApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost("cadastrar")]
    public async Task<IActionResult> CadastrarUsuario([FromBody] CreateUsuarioDto usuarioDto)
    {
        Usuario usuario = await _usuarioService.CadastrarUsuario(usuarioDto);

        return CreatedAtAction(nameof(CadastrarUsuario), usuario.Id ,usuario);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UsuarioLoginDto usuarioLogin)
    {
        string token = await _usuarioService.Login(usuarioLogin);
        return Ok(token);
    }
}

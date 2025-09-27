using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;

namespace UsuariosApi.Services.Interfaces;

public interface IUsuarioService
{
    Task<Usuario> CadastrarUsuario(CreateUsuarioDto usuarioDto);
}

using UsuariosApi.Models;

namespace UsuariosApi.Services.Interfaces;

public interface ITokenService
{
    string GenerateToken(Usuario usuario);
}

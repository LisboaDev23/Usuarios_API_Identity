using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using UsuariosApi.Models;
using UsuariosApi.Services.Interfaces;

namespace UsuariosApi.Services.Behaviours;

public class TokenService : ITokenService
{
    public string GenerateToken(Usuario usuario)
    {
        Claim[] claims = new Claim[]
        {
            new("username", usuario.UserName),
            new("id", usuario.Id),
            new(ClaimTypes.DateOfBirth,
            usuario.DataNascimento.ToString()),
            new("loginTimestamp", DateTime.UtcNow.ToString())
        };

        var chave = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes("SD4FS54DT8WR4F524TERT"));

        var signingCredentials = new SigningCredentials(chave,
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken
            (
            expires: DateTime.Now.AddMinutes(10),
            claims: claims,
            signingCredentials: signingCredentials
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;
using UsuariosApi.Services.Interfaces;

namespace UsuariosApi.Services.Behaviours;

public class UsuarioService : IUsuarioService
{
    private IMapper _mapper;
    private UserManager<Usuario> _userManager;

    public UsuarioService(IMapper mapper, UserManager<Usuario> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<Usuario> CadastrarUsuario (CreateUsuarioDto usuarioDto)
    {
        Usuario usuario = _mapper.Map<Usuario>(usuarioDto);

        IdentityResult result = await _userManager
            .CreateAsync(usuario, usuarioDto.Password);

        if (!result.Succeeded)
        {
            throw new Exception("Falha ao cadastrar usuário");
        }

        return usuario;
    }
}

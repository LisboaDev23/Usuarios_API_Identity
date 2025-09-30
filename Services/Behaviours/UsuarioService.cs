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
    private SignInManager<Usuario> _signInManager;
    private ITokenService _tokenService;

    public UsuarioService
        (
        IMapper mapper, 
        UserManager<Usuario> userManager,
        SignInManager<Usuario> signInManager, 
        ITokenService tokenService
        )
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task<Usuario> CadastrarUsuario(CreateUsuarioDto usuarioDto)
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

    public async Task<string> Login(UsuarioLoginDto usuarioLogin)
    {
        SignInResult result = await _signInManager.PasswordSignInAsync(usuarioLogin.Username, usuarioLogin.Password, false, false);

        if (!result.Succeeded) throw new UnauthorizedAccessException("Usuário não autenticado!");

        var usuario = 
            _signInManager
            .UserManager
            .Users
            .FirstOrDefault(user => user.NormalizedUserName == usuarioLogin.Username.ToUpper());

        var token = _tokenService.GenerateToken(usuario!);

        return token;
    }
}

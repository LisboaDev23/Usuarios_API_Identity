using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Dtos;

public class CreateUsuarioDto
{
    [Required(ErrorMessage = "O campo Nome é obrigatório")]
    public string Username { get; set; }

    [Required(ErrorMessage = "O campo data de nascimento é obrigatório")]
    public DateTime DataNascimento { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [Compare("Password")]
    public string RePassword { get; set; }
}

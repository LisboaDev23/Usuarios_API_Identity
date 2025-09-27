using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Dtos;

public class CreateUsuarioDto
{
    [Required(ErrorMessage = "O campo Nome é obrigatório")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo data de nascimento é obrigatório")]
    public DateTime DataNascimento { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
}

using Microsoft.AspNetCore.Authorization;

namespace UsuariosApi.Authorization;

public class IdadeAuthorization : AuthorizationHandler<IdadeMinimaRequirement>
{

    protected override Task HandleRequirementAsync (
        AuthorizationHandlerContext context, 
        IdadeMinimaRequirement requirement
        )
    {
        var dataNascimentoClaim = context
            .User.FindFirst(claim => claim.Type == "DataNascimento");

        if (dataNascimentoClaim == null)
        {
            context.Fail();
            return Task.CompletedTask;
        }

        var dataNascimento = Convert.ToDateTime(dataNascimentoClaim.Value);
        int idadeUsuario = 
            DateTime.Today.Year - dataNascimento.Year;  

        if (dataNascimento > DateTime.Today.AddYears(-idadeUsuario)) idadeUsuario--;

        if (idadeUsuario >= requirement.Idade) context.Succeed(requirement);

        return Task.CompletedTask;
    }
}

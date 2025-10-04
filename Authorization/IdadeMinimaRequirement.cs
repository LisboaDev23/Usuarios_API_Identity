using Microsoft.AspNetCore.Authorization;

namespace UsuariosApi.Authorization
{
    public class IdadeMinimaRequirement : IAuthorizationRequirement
    {
        public IdadeMinimaRequirement(int idade)
        {
            Idade = idade;
        }
        public int Idade { get; set; }
    }
}

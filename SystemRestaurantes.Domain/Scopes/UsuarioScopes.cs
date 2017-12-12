using SystemRestaurantes.Domain.Entities;
using SystemRestaurantes.SharedKernel.Validation;

namespace SystemRestaurantes.Domain.Scopes
{
    public static class UsuarioScopes
    {
        public static bool CreateUsuarioScopIsValid(this Usuario usuario)
        {
            return AssertionConcern.IsSatisfiedBy(
                AssertionConcern.AssertNotEmpty(usuario.Nome, "O campo nome é Obrigatório!"),
                AssertionConcern.AssertMatches(@"^[a-zA-Z ôÔãÃáÁ]+$", usuario.Nome, "O campo nome deve conter apenas letras!"),
                AssertionConcern.AssertLength(usuario.Nome, 10, "O campo nome é muito curto!"),
                AssertionConcern.AssertNotEmpty(usuario.Senha, "O campo senha é Obrigatória!"),
                AssertionConcern.AssertLength(usuario.Senha, 8, "A senha deve conter no minimo 8 caracteres!"),
                AssertionConcern.AssertNotEmpty(usuario.Email, "O campo email é Obrigatório!"),
                AssertionConcern.AssertIsValidEmail(usuario.Email, "O campo email inválido!"),
                AssertionConcern.AssertNotEmpty(usuario.Perfil, "O campo perfil é Obrigatório!")
                );
        }
        public static bool UpdateUsuarioScopIsValid(this Usuario usuario, string nome, string email, string senha, string perfil)
        {
            return AssertionConcern.IsSatisfiedBy(
                AssertionConcern.AssertNotEmpty(nome, "O campo nome é Obrigatório!"),
                AssertionConcern.AssertMatches(@"^[a-zA-Z ôÔãÃáÁ]+$", usuario.Nome, "O campo nome deve conter apenas letras!"),
                AssertionConcern.AssertLength(usuario.Nome, 10, "O campo nome é muito curto!"),
                AssertionConcern.AssertNotEmpty(senha, "O campo senha é Obrigatória!"),
                AssertionConcern.AssertLength(senha, 8, "A senha deve conter no minimo 8 caracteres!"),
                AssertionConcern.AssertNotEmpty(email, "O campo e-mail é Obrigatório!"),
                AssertionConcern.AssertIsValidEmail(email, "O campo email inválido!"),
                AssertionConcern.AssertNotEmpty(perfil, "O campo perfil é Obrigatório!")
                );
        }

        public static bool AuthenticateUsuarioScopIsValid(this Usuario usuario, string email, string encryptedSenha)
        {
            return AssertionConcern.IsSatisfiedBy(
                AssertionConcern.AssertNotEmpty(email, "O campo email ou senha invalido!"),
                AssertionConcern.AssertIsValidEmail(email, "O campo email ou senha invalido!"),
                AssertionConcern.AssertAreEquals(usuario.Email, email, "O campo email ou senha invalido!"),
                AssertionConcern.AssertNotEmpty(encryptedSenha, "O campo email ou senha invalido!"),
                AssertionConcern.AssertLength(encryptedSenha, 8, "O campo email ou senha invalido!"),
                AssertionConcern.AssertAreEquals(usuario.Senha, encryptedSenha, "O campo email ou senha invalido!")
                );
        }
    }
}

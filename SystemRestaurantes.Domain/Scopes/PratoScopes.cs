using SystemRestaurantes.Domain.Entities;
using SystemRestaurantes.SharedKernel.Validation;

namespace SystemRestaurantes.Domain.Scopes
{
    public static class PratoScopes
    {
        public static bool CreatePratoScopIsValid(this Prato prato)
        {
            return AssertionConcern.IsSatisfiedBy(
                AssertionConcern.AssertNotEmpty(prato.Nome, "O campo nome é Obrigatório!"),
                AssertionConcern.AssertNotEmpty(prato.Preco, "O campo preco é Obrigatório!"),
                AssertionConcern.AssertMatches(@"^[0-9.R$ ]+$", prato.Preco, "O campo nome deve conter apenas letras!")
                );
        }
        public static bool UpdatePratoScopIsValid(this Prato prato, string nome, string preco)
        {
            return AssertionConcern.IsSatisfiedBy(
                AssertionConcern.AssertNotEmpty(nome, "O campo nome é Obrigatório!"),
                AssertionConcern.AssertNotEmpty(preco, "O campo preco é Obrigatório!"),
                AssertionConcern.AssertMatches(@"^[0-9.R$ ]+$", preco, "O campo nome deve conter apenas letras!")
                );
        }
    }
}

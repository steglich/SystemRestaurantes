using System.Collections.Generic;
using SystemRestaurantes.Domain.Commands.PratoCommand;
using SystemRestaurantes.Domain.Entities;

namespace SystemRestaurantes.Domain.Services
{
    public interface IPratoApplicationService
    {
        List<Prato> GetAll(string restaurante);
        Prato GetPrato(string restaurante, string nome);
        Prato GetOne(string nome);
        Prato GetId(int id);
        Prato Create(RegisterPratoCommand command);
        Prato Update(UpdatePratoCommand command);
        Prato Delete(DeletePratoCommand command);
    }
}

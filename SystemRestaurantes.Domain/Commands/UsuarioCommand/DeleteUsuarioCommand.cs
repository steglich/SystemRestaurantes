namespace SystemRestaurantes.Domain.Commands.UsuarioCommand
{
    public class DeleteUsuarioCommand
    {
        public DeleteUsuarioCommand(string email)
        {
            this.Email = email;
        }
        
        public string Email { get; set; }
    }
}

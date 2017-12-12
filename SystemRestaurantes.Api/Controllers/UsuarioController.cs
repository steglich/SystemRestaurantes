using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SystemRestaurantes.Domain.Commands.UsuarioCommand;
using SystemRestaurantes.Domain.Services;

namespace SystemRestaurantes.Api.Controllers
{
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioApplicationService _service;

        public UsuarioController(IUsuarioApplicationService service)
        {
            this._service = service;
        }
        
        [HttpPost]
        [Route("api/usuarios/create/")]
        public Task<HttpResponseMessage> PostCad([FromBody]dynamic body) // Cadastra os usuários
        {
            var response = new HttpResponseMessage();
            try
            {
                var usuariosExiste = _service.GetByEmail((string)body.email);
                try
                {
                    if (usuariosExiste.Email.Equals((string)body.email))
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK, "Este usuário já esta cadastrado!");
                    }
                }
                catch
                {
                    var command = new RegisterUsuarioCommand(
                    email: (string)body.email,
                    senha: (string)body.senha,
                    nome: (string)body.nome,
                    perfil: (string)body.perfil
                    );

                    var usuarios = _service.Create(command);

                    return CreateResponse(HttpStatusCode.Created, usuarios);
                }
                
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Não foi criado o usuário!");
            }
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [HttpPost]
        [Route("api/usuarios/valida/")]
        public Task<HttpResponseMessage> PostAutentica([FromBody]dynamic body) // Verifica se o usuário e validado
        {
            var response = new HttpResponseMessage();

            var usuarios = _service.GetAuthenticateUsuario((string)body.email, (string)body.senha);

            if (usuarios == null)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Email ou Senha inválido!");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, usuarios);
            }
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [HttpPost]
        [Route("api/usuarios/getEmail/")]
        public Task<HttpResponseMessage> GetEmail([FromBody]dynamic body) // retorna usuário por e-mail
        {
            var response = new HttpResponseMessage();
            try
            {
                var usuarios = _service.GetByEmail((string)body.email);
                response = Request.CreateResponse(HttpStatusCode.OK, usuarios);
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Procura por email não encontrada!");
            }
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;

        }

        [HttpGet]
        [Route("api/usuarios/getAll/")]
        public Task<HttpResponseMessage> GetAll() // Retorna todos os usuários
        {
            var response = new HttpResponseMessage();
            try
            {
                var usuarios = _service.GetAll();
                response = Request.CreateResponse(HttpStatusCode.OK, usuarios);
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Procura por email não encontrada!");
            }
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;

        }

        [HttpPut]
        [Route("api/usuarios/update/")]
        public Task<HttpResponseMessage> Put([FromBody]dynamic body) // Atualiza usuário
        {
            var usuariosUpdate = _service.GetByEmail((string)body.emailOld);

            var response = new HttpResponseMessage();
            try
            {
                var command = new UpdateUsuarioCommand(
                    id: usuariosUpdate.UsuarioId,
                    email: (string)body.email,
                    senha: (string)body.senha,
                    nome: (string)body.nome,
                    perfil: (string)body.perfil
                );

                var usuarios = _service.Update(command);
                response = Request.CreateResponse(HttpStatusCode.OK, "Atualizado com sucesso!");
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Não foi Atualizado o usuário!");
            }
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [HttpDelete]
        [Route("api/usuarios/deleta/")]
        public Task<HttpResponseMessage> deleteEmail([FromBody]dynamic body) // Deleta o ususário
        {
            var response = new HttpResponseMessage();
            try
            {
                var command = new DeleteUsuarioCommand((string)body.email);

                var usuarios = _service.Delete(command);

                response = Request.CreateResponse(HttpStatusCode.OK, "Apagado com sucesso!");
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Email não encontrado!");
            }
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;

        }
    }
}
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SystemRestaurantes.Domain.Commands.RetauranteCommand;
using SystemRestaurantes.Domain.Services;

namespace SystemRestaurantes.Api.Controllers
{
    public class RestauranteController : BaseController
    {
        private readonly IRestauranteApplicationService _service;
        private readonly IUsuarioApplicationService _serviceUsuario;

        public RestauranteController(IRestauranteApplicationService service, IUsuarioApplicationService serviceUsuario)
        {
            this._service = service;
            this._serviceUsuario = serviceUsuario;
        }

        [HttpPost]
        [Route("api/restaurante/create/")]
        public Task<HttpResponseMessage> PostCad([FromBody]dynamic body) // Cadastrar os restaurantes
        {
            var response = new HttpResponseMessage();
            try
            {
                var restauranteExiste = _service.GetOne((string)body.nome);
                try
                {
                    if (restauranteExiste.Nome.Equals((string)body.nome))
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK, "Este restaurante já esta cadastrado!");
                    }
                }
                catch
                {
                    var usuarios = _serviceUsuario.GetByEmail((string)body.email);

                    var command = new RegisterRestauranteCommand(
                    nome: (string)body.nome,
                    bairro: (string)body.bairro,
                    rua: (string)body.rua,
                    numero: (int)body.numero,
                    usuarioId: usuarios.UsuarioId
                    );

                    var restaurante = _service.Create(command);

                    return CreateResponse(HttpStatusCode.Created, restaurante);
                }

            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Não foi criado o restaurante!");
            }
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [HttpGet]
        [Route("api/restaurante/getOne/{nome}")]
        public Task<HttpResponseMessage> GetOne(string nome) // retorna restaurante por nome
        {
            var response = new HttpResponseMessage();
            try
            {
                var restaurante = _service.GetOne(nome);
                response = Request.CreateResponse(HttpStatusCode.OK, restaurante);
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Procura por restaurante não encontrada!");
            }
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [HttpGet]
        [Route("api/restaurante/getAll/")]
        public Task<HttpResponseMessage> GetAll() // Retorna todos os restaurantes
        {
            var response = new HttpResponseMessage();
            try
            {
                var restaurante = _service.GetAll();
                response = Request.CreateResponse(HttpStatusCode.OK, restaurante);
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Nenhum restaurante encontrado!");
            }
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;

        }

        [HttpPost]
        [Route("api/restaurante/getEmail/")]
        public Task<HttpResponseMessage> GetEmail([FromBody]dynamic body) // retorna restaurantes por usuario
        {
            var response = new HttpResponseMessage();
            try
            {
                var restaurante = _service.GetByRestaurante((string)body.email);
                response = Request.CreateResponse(HttpStatusCode.OK, restaurante);
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Nenhum restaurante encontrado!");
            }
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;

        }

        [HttpPut]
        [Route("api/restaurante/update/")]
        public Task<HttpResponseMessage> Put([FromBody]dynamic body) // Atualiza restaurante
        {
            var restauranteUpdate = _service.GetOne((string)body.nomeOld);

            var response = new HttpResponseMessage();
            try
            {
                var command = new UpdateRestauranteCommand(
                    restauranteId: restauranteUpdate.RestauranteId,
                    nome: (string)body.nome,
                    bairro: (string)body.bairro,
                    rua: (string)body.rua,
                    numero: (int)body.numero
                );

                var restaurante = _service.Update(command);
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
        [Route("api/restaurante/deleta/")]
        public Task<HttpResponseMessage> deleteEmail([FromBody]dynamic body) // Deleta o restaurante
        {
            var response = new HttpResponseMessage();
            try
            {
                var command = new DeleteRestauranteCommand((string)body.nome);

                var restaurante = _service.Delete(command);

                response = Request.CreateResponse(HttpStatusCode.OK, "Apagado com sucesso!");
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Restaurante não encontrado!");
            }
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;

        }
    }
}
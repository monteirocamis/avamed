using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Avamed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {

        [HttpGet]
        [Route("/ListarTodosAgendamentos")]
        public string Get()
        {
            return "Olá";
        }


    }
}

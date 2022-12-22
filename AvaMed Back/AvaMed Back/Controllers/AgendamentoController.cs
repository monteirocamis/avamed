using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Data.Dto;

namespace AvaMed_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly Projeto.Data.Contexto.AvamedContext _contexto;
        private readonly Projeto.Data.Interfaces.IAgendamentoRepositorio _agendamentoRepositorio;
        public AgendamentoController(
            Projeto.Data.Contexto.AvamedContext _contexto,
            Projeto.Data.Interfaces.IAgendamentoRepositorio agendamentoRepositorio)
        {
            _contexto = _contexto;
            _agendamentoRepositorio = agendamentoRepositorio;
        }

        [HttpGet]
        [Route("/ListarAgendamentos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Projeto.Data.Dto.AgendamentoDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarAgendamentos()
        {
            try
            {
                return Ok(_agendamentoRepositorio.ListarAgendamentos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("/ListarAgendamentosPorId")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Projeto.Data.Dto.AgendamentoDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarAgendamentosPorId(int idAgendamento)
        {
            try
            {
                if(idAgendamento < 1 || idAgendamento == null)
                {
                    return BadRequest("O código informado não existe ou é nulo");
                }
                return Ok(_agendamentoRepositorio.ListarAgendamentosPorId(idAgendamento));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("/CadastrarAgendamento")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Cadastrar(AgendamentoDto agendamentoCadastrarDto)
        {
            try
            {
                if(agendamentoCadastrarDto == null)
                {
                    return BadRequest("Algum parâmetro está nulo");
                }
                return Ok(_agendamentoRepositorio.Cadastrar(agendamentoCadastrarDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("/AtualizarAgendamento")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Atualizar(AgendamentoDto agendamentoDto)
        {
            try
            {
                if (agendamentoDto == null || agendamentoDto.IdAgendamento < 0)
                {
                    return BadRequest("Algum dos parâmetors está nulo ou id é menor que 0");
                }

                return Ok(_agendamentoRepositorio.Atualizar(agendamentoDto));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Route("/ExcluirAgendamento")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Excluir(int id)
        {
            try
            {
                if (id < 1)
                {
                    return BadRequest("O id informado é menor do que 1");
                }

                return Ok(_agendamentoRepositorio.Excluir(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Projeto.Data.Dto;
using Projeto.Data.Entidades;
using System.Data;

namespace AvaMed_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadesController : ControllerBase
    {
        private readonly Projeto.Data.Contexto.AvamedContext _contexto;
        private readonly Projeto.Data.Interfaces.IEspecialidadeRepositorio _especialidadeRepositorio;

        public EspecialidadesController(
            Projeto.Data.Contexto.AvamedContext contexto,
            Projeto.Data.Interfaces.IEspecialidadeRepositorio especialidadeRepositorio)
        {
            _contexto = contexto;
            _especialidadeRepositorio = especialidadeRepositorio;
        }


        [HttpGet]
        [Route("/listarEspecialidades")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Projeto.Data.Dto.EspecialidadeDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarEspecialidades()
        {

            try
            {
                return Ok(_especialidadeRepositorio.ListarEspecialidades());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("/listarEspecialidadesPorId")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Projeto.Data.Dto.EspecialidadeDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarEspecialidadePorId(int idEspecialidade)
        {

            try
            {
                if (idEspecialidade < 1 || idEspecialidade == null)
                {
                    return BadRequest("O código informado é menor do que 1 ou é nulo");
                }

                return Ok(_especialidadeRepositorio.ListarEspecialidadePorId(idEspecialidade));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("/CadastrarEspecialidade")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Cadastrar(EspecialidadeCadastrarDto especialidadeCadastrarDto)
        {
            try
            {
                if (especialidadeCadastrarDto == null ||
                    String.IsNullOrEmpty(especialidadeCadastrarDto.Nome) ||
                    !especialidadeCadastrarDto.Ativo)
                {
                    return BadRequest("Algum dos parâmetors está nulo");
                }

                

                return Ok(_especialidadeRepositorio.Cadastrar(especialidadeCadastrarDto));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("/atualizarEspecialidade")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Atualizar(EspecialidadeAtualizarDto especialidadeAtualizarDto)
        {
            try
            {
                if(especialidadeAtualizarDto == null || especialidadeAtualizarDto.IdEspecialidade < 0)
                {
                    return BadRequest("Algum dos parâmetors está nulo ou id é menor que 0");
                }

                return Ok(_especialidadeRepositorio.Atualizar(especialidadeAtualizarDto));

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("/ExcluirEspecialidade")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Excluir (int id)
        {
            try
            {
                if (id < 1)
                {
                    return BadRequest("O id informado é menor do que 1");
                }

                return Ok(_especialidadeRepositorio.Excluir(id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

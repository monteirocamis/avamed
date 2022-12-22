using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Data.Contexto;
using Projeto.Data.Dto;
using Projeto.Data.Interfaces;
using Projeto.Data.Repositorio;

namespace AvaMed_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfissionalController : ControllerBase
    {
        private readonly Projeto.Data.Contexto.AvamedContext _contexto;
        private readonly Projeto.Data.Interfaces.IProfissionalRepositorio _profissionalRepositorio;

        public ProfissionalController(AvamedContext contexto, IProfissionalRepositorio profissionalRepositorio)
        {
            _contexto = contexto;
            _profissionalRepositorio = profissionalRepositorio;
        }

        [HttpGet]
        [Route("/ListarProfissionais")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Projeto.Data.Dto.ProfissionalDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarProfissionais()
        {

            try
            {
                return Ok(_profissionalRepositorio.ListarProfissionais());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("/ListarProfissionalPorId")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Projeto.Data.Dto.ProfissionalDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarProfissionalPorId(int idProfissional)
        {

            try
            {
                if (idProfissional < 1 || idProfissional == null)
                {
                    return BadRequest("O código informado é menor do que 1 ou é nulo");
                }

                return Ok(_profissionalRepositorio.ListarProfissionalPorId(idProfissional));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("/CadastrarProfissional")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Cadastrar(ProfissionalDto profissionalCadastrar)
        {
            try
            {
                if (profissionalCadastrar == null ||
                    String.IsNullOrEmpty(profissionalCadastrar.Nome) ||
                    !profissionalCadastrar.Ativo)
                {
                    return BadRequest("Algum dos parâmetors está nulo");
                }

                return Ok(_profissionalRepositorio.Cadastrar(profissionalCadastrar));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("/atualizarProfissional")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Atualizar(ProfissionalDto profissionalAtualizar)
        {
            try
            {
                if (profissionalAtualizar == null || profissionalAtualizar.IdProfissional < 0)
                {
                    return BadRequest("Algum dos parâmetors está nulo ou id é menor que 0");
                }

                return Ok(_profissionalRepositorio.Atualizar(profissionalAtualizar));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("/ExcluirProfissional")]
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

                return Ok(_profissionalRepositorio.Excluir(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

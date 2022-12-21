using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Data.Dto;
using System.Data;

namespace AvaMed_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficiariosController : ControllerBase
    {
        private readonly Projeto.Data.Contexto.AvamedContext _contexto;
        private readonly Projeto.Data.Interfaces.IBeneficiarioRepositorio _beneficiarioRepositorio;

        public BeneficiariosController(
            Projeto.Data.Contexto.AvamedContext _contexto,
            Projeto.Data.Interfaces.IBeneficiarioRepositorio beneficiarioRepositorio)
        {
            _contexto = _contexto;
            _beneficiarioRepositorio = beneficiarioRepositorio;
        }


        [HttpGet]
        [Route("/ListarBeneficiarios")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Projeto.Data.Dto.BeneficiarioDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarBeneficiarios()
        {

            try
            {
                return Ok(_beneficiarioRepositorio.ListarBeneficiarios());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("/ListarBeneficiariosPorId")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Projeto.Data.Dto.EspecialidadeDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarBeneficiarioPorId(int idBeneficiario)
        {

            try
            {
                if (idBeneficiario < 1 || idBeneficiario == null)
                {
                    return BadRequest("O código informado é menor do que 1 ou é nulo");
                }

                return Ok(_beneficiarioRepositorio.ListarBeneficiarioPorId(idBeneficiario));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("/CadastrarBeneficiario")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Cadastrar(BeneficiarioCadastrarDto beneficiarioCadastrarDto)
        {
            try
            {
                if (beneficiarioCadastrarDto == null ||
                    String.IsNullOrEmpty(beneficiarioCadastrarDto.Nome) ||
                    !beneficiarioCadastrarDto.Ativo)
                {
                    return BadRequest("Algum dos parâmetors está nulo");
                }



                return Ok(_beneficiarioRepositorio.Cadastrar(beneficiarioCadastrarDto));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("/atualizarBeneficiario")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Atualizar(BeneficiarioCadastrarDto beneficiarioCadastrarDto)
        {
            try
            {
                if (beneficiarioCadastrarDto == null || beneficiarioCadastrarDto.IdBeneficiario < 0)
                {
                    return BadRequest("Algum dos parâmetors está nulo ou id é menor que 0");
                }

                return Ok(_beneficiarioRepositorio.Atualizar(beneficiarioCadastrarDto));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }


        [HttpDelete]
        [Route("/ExcluirBeneficiario")]
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

                return Ok(_beneficiarioRepositorio.Excluir(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
    }

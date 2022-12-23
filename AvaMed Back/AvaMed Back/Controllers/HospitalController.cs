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
    public class HospitalController : ControllerBase
    {
        private readonly Projeto.Data.Contexto.AvamedContext _contexto;
        private readonly Projeto.Data.Interfaces.IHospitalRepositorio _hospitalRepositorio;

        public HospitalController(
            Projeto.Data.Contexto.AvamedContext contexto,
            Projeto.Data.Interfaces.IHospitalRepositorio especialidadeRepositorio)
        {
            _contexto = contexto;
            _hospitalRepositorio = especialidadeRepositorio;
        }


        [HttpGet]
        [Route("/listarHospitais")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Projeto.Data.Dto.HospitalDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarEspecialidades()
        {

            try
            {
                return Ok(_hospitalRepositorio.ListarHospitais());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("/ListarHospitalPorId")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Projeto.Data.Dto.HospitalDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarHospitalPorId(int idHospital)
        {

            try
            {
                if (idHospital < 1 || idHospital == null)
                {
                    return BadRequest("O código informado é menor do que 1 ou é nulo");
                }

                return Ok(_hospitalRepositorio.ListarHospitalPorId(idHospital));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("/CadastrarHospital")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Cadastrar(HospitalCadastrarDto hospitalCadastrarDto)
        {
            try
            {
                if (hospitalCadastrarDto == null ||
                    String.IsNullOrEmpty(hospitalCadastrarDto.Nome) ||
                    !hospitalCadastrarDto.Ativo)
                {
                    return BadRequest("Algum dos parâmetors está nulo");
                }



                return Ok(_hospitalRepositorio.Cadastrar(hospitalCadastrarDto));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("/atualizarHospital")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Atualizar(HospitalCadastrarDto hospitalCadastrarDto)
        {
            try
            {
                if (hospitalCadastrarDto == null || hospitalCadastrarDto.IdHospital < 0)
                {
                    return BadRequest("Algum dos parâmetors está nulo ou id é menor que 0");
                }

                return Ok(_hospitalRepositorio.Atualizar(hospitalCadastrarDto));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpDelete]
        [Route("/ExcluirHospital")]
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

                return Ok(_hospitalRepositorio.Excluir(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}

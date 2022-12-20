using Avamed.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Avamed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficiariosController : ControllerBase
    {
        private readonly Interfaces.IBeneficiarioRepositorio _beneficiariosRepository;

        public BeneficiariosController(
           Interfaces.IBeneficiarioRepositorio beneficiariosRepositorio)
        {
            _beneficiariosRepository = beneficiariosRepositorio;
        }


        [HttpGet]
        [Route("/ListarTodosBeneficiarios")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Dto.BeneficiarioDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarTodos()
        {

            try
            {
                List<BeneficiarioDto> resultado = _beneficiariosRepository.ListarTodos();

                if (resultado == null)
                {
                    return NoContent();
                }

                if (resultado.Count == 0)
                {
                    throw new Exception("Sem elementos");
                }

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        

    }
}

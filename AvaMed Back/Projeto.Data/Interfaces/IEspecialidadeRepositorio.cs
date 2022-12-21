using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Data.Interfaces
{
    public interface IEspecialidadeRepositorio
    {
        public List <Dto.EspecialidadeDto> ListarEspecialidades();

        Dto.EspecialidadeDto ListarEspecialidadePorId(int idEspecialidade);

        int Cadastrar(Dto.EspecialidadeCadastrarDto cadastarEspecialidade);

        int Atualizar(Dto.EspecialidadeAtualizarDto atualizarEspecialidade);

        int Excluir(int idEspecialidade);

    }
}

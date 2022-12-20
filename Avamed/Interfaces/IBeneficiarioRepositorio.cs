using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avamed.Interfaces
{
    public interface IBeneficiarioRepositorio
    {
        List<Dto.BeneficiarioDto> ListarTodos();

        Dto.BeneficiarioDto PorId(int id);

        int Cadastrar(Dto.BeneficiarioCadastrarDto cadastrarDto);

        int Atualizar(Dto.BeneficiarioCadastrarDto cadastrarDto);

        int Excluir(int Id);
    }
}
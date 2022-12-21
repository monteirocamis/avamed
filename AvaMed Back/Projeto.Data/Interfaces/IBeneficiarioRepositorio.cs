using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Data.Interfaces
{
    public interface IBeneficiarioRepositorio
    {
        public List<Dto.BeneficiarioDto> ListarBeneficiarios();

        Dto.BeneficiarioDto ListarBeneficiarioPorId(int IdBeneficiario);

        int Cadastrar(Dto.BeneficiarioCadastrarDto cadastrarBeneficiarioDto);

        int Atualizar(Dto.BeneficiarioCadastrarDto cadastrarBeneficiarioDto);

        int Excluir(int IdBeneficiario);
    }
}

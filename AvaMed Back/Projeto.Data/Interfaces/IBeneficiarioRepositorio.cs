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

        public Dto.BeneficiarioDto ListarBeneficiarioPorId(int IdBeneficiario);

        public int Cadastrar(Dto.BeneficiarioCadastrarDto cadastrarBeneficiarioDto);

        public int Atualizar(Dto.BeneficiarioCadastrarDto cadastrarBeneficiarioDto);

        public int Excluir(int IdBeneficiario);
    }
}

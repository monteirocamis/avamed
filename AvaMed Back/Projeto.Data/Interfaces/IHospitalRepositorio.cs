using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Data.Interfaces
{
    public interface IHospitalRepositorio
    {

        public List<Dto.HospitalDto> ListarHospitais();

        Dto.HospitalDto ListarHospitalPorId(int IdHospital);

        int Cadastrar(Dto.HospitalCadastrarDto hospitalCadastrarDto);

        int Atualizar(Dto.HospitalCadastrarDto hospitalCadastrarDto);

        int Excluir(int IdHospital);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Data.Interfaces
{
    public interface IProfissionalRepositorio
    {
        public List<Dto.ProfissionalDto> ListarProfissionais();
        public Dto.ProfissionalDto ListarProfissionalPorId(int IdProfissional);
        public int Cadastrar(Dto.ProfissionalDto cadastrarProfissionalDto);
        public int Atualizar(Dto.ProfissionalDto atualizarProfissionalDto);
        public int Excluir(int IdProfissional);
    }
}

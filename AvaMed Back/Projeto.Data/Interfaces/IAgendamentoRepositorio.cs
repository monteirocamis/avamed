using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Data.Interfaces
{
    public interface IAgendamentoRepositorio
    {
        public List<Dto.AgendamentoDto> ListarAgendamentos();
        public Dto.AgendamentoDto ListarAgendamentosPorId(int IdAgendamento);
        public int Cadastrar(Dto.AgendamentoDto cadastrarAgendamento);
        public int Atualizar(Dto.AgendamentoDto atualizarAgendamento);
        public int Excluir(int IdAgendamento);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Data.Dto
{
    public class AgendamentoDto
    {
        public int IdAgendamento { get; set; }
        public int IdHospital { get; set; }
        public int IdEspecialidade { get; set; }
        public int IdProfissional { get; set; }
        public DateTime DataHoraAgendamento { get; set; }
        public int IdBeneficiario { get; set; }
        public bool Ativo { get; set; }
    }
}

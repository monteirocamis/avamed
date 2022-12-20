using Avamed.Database;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Avamed.Dto {
    public class AgendamentoConfiguracao {
        public int IdConfiguracao { get; set; }
        public int IdHospital { get; set; }
        public int IdEspecialidade { get; set; }
        public int IdProfissional { get; set; }
        public DateTime DataHoraInicioAtendimento { get; set; }
        public DateTime DataHoraFinalAtendimento { get; set; }
        public virtual Especialidade IdEspecialidadeNavigation { get; set; } = null!;
        public virtual Hospital IdHospitalNavigation { get; set; } = null!;
        public virtual Profissional IdProfissionalNavigation { get; set; } = null!;

    }
}
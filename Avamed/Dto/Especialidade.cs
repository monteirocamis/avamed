using Avamed.Database;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Avamed.Dto;

public partial class Especialidade
{
    public int IdEspecialidade { get; set; }
    public string Nome { get; set; } = null!;
    public string? Descrição { get; set; }
    public bool Ativo { get; set; }
    public virtual ICollection<AgendamentoConfiguracao> AgendamentoConfiguracaos { get; } = new List<AgendamentoConfiguracao>();
    public virtual ICollection<Agendamento> Agendamentos { get; } = new List<Agendamento>();
}

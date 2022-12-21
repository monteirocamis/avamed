using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Data.Dto
{
    public class EspecialidadeDto
    {

        public int IdEspecialidade { get; set; }

        public string Nome { get; set; } = null!;

        public string? Descrição { get; set; }

        public bool Ativo { get; set; }

    }
}

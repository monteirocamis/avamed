using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Data.Dto
{
    public class ProfissionalDto
    {
        public int IdProfissional { get; set; }
        public string Nome { get; set; } = null!;
        public string? Telefone { get; set; }
        public string? Endereco { get; set; }
        public bool Ativo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Data.Dto
{
    public class BeneficiarioDto
    {

        public int IdBeneficiario { get; set; }

        public string Nome { get; set; } = null!;

        public string Cpf { get; set; } = null!;

        public string? Telefone { get; set; }

        public string? Endereco { get; set; }

        public string NumeroCarteirinha { get; set; } = null!;

        public bool Ativo { get; set; }

        public string Email { get; set; } = null!;

        public string Senha { get; set; } = null!;

    }
}

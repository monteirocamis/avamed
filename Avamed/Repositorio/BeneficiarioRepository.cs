using Avamed.Database;
using Avamed.Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avamed.Repository
{
    public class BeneficiarioRepository
    {
        private readonly ApplicationDbContext _context;

        public BeneficiarioRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public List<Dto.BeneficiarioDto> Beneficiarios (int id)
        {
            return _context.Beneficiarios
                .Where(w=>w.IdBeneficiario == id )
                .Select(s => new Dto.BeneficiarioDto
                {
                    IdBeneficiario = s.IdBeneficiario,
                    Nome = s.Nome,
                    Cpf = s.Cpf,
                    Telefone = s.Telefone,
                    Endereco = s.Endereco,
                    NumeroCarteirinha = s.NumeroCarteirinha,
                    Ativo = s.Ativo,
                    Email = s.Email,
                    Senha = s.Senha
                }).ToList();
        }

        public List <Dto.BeneficiarioDto> BeneficiariosLambda(int id)
        {
            return (from a in _context.Beneficiarios
                    where a.IdBeneficiario == id
                    select new Dto.BeneficiarioDto()
                    {
                        IdBeneficiario = a.IdBeneficiario,
                        Nome = a.Nome,
                        Cpf = a.Cpf,
                        Telefone = a.Telefone,
                        Endereco = a.Endereco,
                        NumeroCarteirinha = a.NumeroCarteirinha,
                        Ativo = a.Ativo,
                        Email = a.Email,
                        Senha = a.Senha
                    }).ToList();
        }

    }
}

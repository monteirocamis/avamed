using Projeto.Data.Dto;
using Projeto.Data.Entidades;
using Projeto.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Data.Repositorio
{
    public class BeneficiarioRepositorio : IBeneficiarioRepositorio
    {

        private readonly Contexto.AvamedContext _contexto;

        public BeneficiarioRepositorio(Contexto.AvamedContext contexto)
        {
            _contexto = contexto;
        }

        public int Atualizar(BeneficiarioCadastrarDto cadastrarBeneficiarioDto)
        {
            Entidades.Beneficiario beneficiarioEntidadeBanco =
                (from b in _contexto.Beneficiarios
                 where b.IdBeneficiario == cadastrarBeneficiarioDto.IdBeneficiario
                 select b)
                 .FirstOrDefault();

            if (beneficiarioEntidadeBanco== null)
            {
                return 0;
            }

            beneficiarioEntidadeBanco.Nome = cadastrarBeneficiarioDto.Nome;
            beneficiarioEntidadeBanco.Cpf = cadastrarBeneficiarioDto.Cpf;
            beneficiarioEntidadeBanco.Telefone = cadastrarBeneficiarioDto.Telefone;
            beneficiarioEntidadeBanco.Endereco = cadastrarBeneficiarioDto.Endereco;
            beneficiarioEntidadeBanco.NumeroCarteirinha = cadastrarBeneficiarioDto.NumeroCarteirinha;
            beneficiarioEntidadeBanco.Ativo = cadastrarBeneficiarioDto.Ativo;
            beneficiarioEntidadeBanco.Email = cadastrarBeneficiarioDto.Email;
            beneficiarioEntidadeBanco.Senha = cadastrarBeneficiarioDto.Senha;

            return _contexto.SaveChanges();
        }

        public int Cadastrar(BeneficiarioCadastrarDto cadastrarBeneficiarioDto)
        {
            Entidades.Beneficiario beneficiarioEntidade = new Entidades.Beneficiario()
            {
                Nome = cadastrarBeneficiarioDto.Nome                                ,
                Cpf = cadastrarBeneficiarioDto.Cpf                                  ,
                Telefone = cadastrarBeneficiarioDto.Telefone                        ,
                Endereco = cadastrarBeneficiarioDto.Endereco                        ,
                NumeroCarteirinha = cadastrarBeneficiarioDto.NumeroCarteirinha      ,
                Ativo = cadastrarBeneficiarioDto.Ativo                              ,
                Email = cadastrarBeneficiarioDto.Email                              ,
                Senha = cadastrarBeneficiarioDto.Senha
            };

            _contexto.ChangeTracker.Clear();
            _contexto.Beneficiarios.Add(beneficiarioEntidade);
            return _contexto.SaveChanges();


            throw new NotImplementedException();
        }

        public int Excluir(int IdBeneficiario)
        {
            Entidades.Beneficiario beneficiarioEntidade=
                (from b in _contexto.Beneficiarios
                 where b.IdBeneficiario== IdBeneficiario
                 select b).FirstOrDefault();

            if ( beneficiarioEntidade == null || DBNull.Value.Equals(beneficiarioEntidade.IdBeneficiario) || beneficiarioEntidade.IdBeneficiario == 0)
            {
                return 0;
            }

            _contexto.ChangeTracker.Clear();
            _contexto.Beneficiarios.Remove(beneficiarioEntidade);
            return _contexto.SaveChanges();

            throw new NotImplementedException();
        }

        public BeneficiarioDto ListarBeneficiarioPorId(int IdBeneficiario)
        {
            return (from b in _contexto.Beneficiarios
                    where b.IdBeneficiario == IdBeneficiario
                    select new Dto.BeneficiarioDto()
                    {
                        Nome = b.Nome,
                        Cpf = b.Cpf,
                        Telefone = b.Telefone,
                        Endereco = b.Endereco,
                        NumeroCarteirinha = b.NumeroCarteirinha,
                        Ativo = b.Ativo,
                        Email = b.Email,
                        Senha = b.Senha
                    })
                    ?.FirstOrDefault()
                    ?? new BeneficiarioDto();
        }

        public List <Dto.BeneficiarioDto> ListarBeneficiarios()
        {
            return (from b in _contexto.Beneficiarios
                    select new Dto.BeneficiarioDto()
                    {
                        IdBeneficiario = b.IdBeneficiario,
                        Nome = b.Nome,
                        Cpf = b.Cpf,
                        Telefone = b.Telefone,
                        Endereco = b.Endereco,
                        NumeroCarteirinha = b.NumeroCarteirinha,
                        Ativo = b.Ativo,
                        Email = b.Email,
                        Senha = b.Senha
                    }).ToList();
        }


    }
}

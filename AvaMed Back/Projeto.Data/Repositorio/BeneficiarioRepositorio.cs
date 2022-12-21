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
                Entidades.Beneficiario beneficiarioEntidadeSalvarBanco =
                (from b in _contexto.Beneficiarios
                 where b.IdBeneficiario == cadastrarBeneficiarioDto.IdBeneficiario
                 select b)
                 .FirstOrDefault();

            if (beneficiarioEntidadeSalvarBanco == null)
            {
                return 0;
            }

            beneficiarioEntidadeSalvarBanco.Nome = cadastrarBeneficiarioDto.Nome;
            beneficiarioEntidadeSalvarBanco.Cpf = cadastrarBeneficiarioDto.Cpf;
            beneficiarioEntidadeSalvarBanco.Telefone = cadastrarBeneficiarioDto.Telefone;
            beneficiarioEntidadeSalvarBanco.Endereco = cadastrarBeneficiarioDto.Endereco;
            beneficiarioEntidadeSalvarBanco.NumeroCarteirinha = cadastrarBeneficiarioDto.NumeroCarteirinha;
            beneficiarioEntidadeSalvarBanco.Ativo = cadastrarBeneficiarioDto.Ativo;
            beneficiarioEntidadeSalvarBanco.Email = cadastrarBeneficiarioDto.Email;
            beneficiarioEntidadeSalvarBanco.Senha = cadastrarBeneficiarioDto.Senha;

                return _contexto.SaveChanges();


            throw new NotImplementedException();
        }

        public int Cadastrar(BeneficiarioCadastrarDto cadastrarBeneficiarioDto)
        {
            Entidades.Beneficiario beneficiarioEntidade = new Entidades.Beneficiario()
            {
                Nome = cadastrarBeneficiarioDto.Nome,
                Cpf = cadastrarBeneficiarioDto.Cpf,
                Telefone = cadastrarBeneficiarioDto.Telefone,
                Endereco = cadastrarBeneficiarioDto.Endereco,
                NumeroCarteirinha = cadastrarBeneficiarioDto.NumeroCarteirinha,
                Ativo = cadastrarBeneficiarioDto.Ativo,
                Email = cadastrarBeneficiarioDto.Email,
                Senha = cadastrarBeneficiarioDto.Senha
            };

            _contexto.ChangeTracker.Clear();
            _contexto.Beneficiarios.Add(beneficiarioEntidade);
            return  _contexto.SaveChanges();
            throw new NotImplementedException();
        }

        public int Excluir(int IdBeneficiario)
        {   
            Entidades.Beneficiario beneficiarioExcluirBanco  = 
                (from b in _contexto.Beneficiarios
                 where b.IdBeneficiario== IdBeneficiario
                 select b).FirstOrDefault();

            if(beneficiarioExcluirBanco == null || DBNull.Value.Equals(beneficiarioExcluirBanco.IdBeneficiario)|| beneficiarioExcluirBanco.IdBeneficiario == 0)
            {
                return 0;
            }

            _contexto.ChangeTracker.Clear();
            _contexto.Beneficiarios.Remove(beneficiarioExcluirBanco);
            return _contexto.SaveChanges();
            throw new NotImplementedException();
        }

        public BeneficiarioDto ListarBeneficiarioPorId(int IdBeneficiario)
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
                    })?.FirstOrDefault()
                    ?? new BeneficiarioDto();
            throw new NotImplementedException();
        }

        public List<BeneficiarioDto> ListarBeneficiarios()
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
            throw new NotImplementedException();
        }
    }
}

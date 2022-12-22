using Projeto.Data.Contexto;
using Projeto.Data.Dto;
using Projeto.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Data.Repositorio
{
    public class ProfissionalRepositorio : IProfissionalRepositorio
    {
        private readonly Contexto.AvamedContext _contexto;

        public ProfissionalRepositorio(AvamedContext contexto)
        {
            _contexto = contexto;
        }

        public int Atualizar(ProfissionalDto atualizarProfissionalDto)
        {
            Entidades.Profissional profissionalAtualizar = 
                (from p in _contexto.Profissionals
                 where p.IdProfissional == atualizarProfissionalDto.IdProfissional
                 select p).FirstOrDefault();

            if(profissionalAtualizar == null)
            {
                return 0;
            }

            profissionalAtualizar.Nome = atualizarProfissionalDto.Nome;
            profissionalAtualizar.Telefone = atualizarProfissionalDto.Telefone;
            profissionalAtualizar.Endereço = atualizarProfissionalDto.Endereco;
            profissionalAtualizar.Ativo = atualizarProfissionalDto.Ativo;

            return _contexto.SaveChanges();
            throw new NotImplementedException();
        }

        public int Cadastrar(ProfissionalDto cadastrarProfissionalDto)
        {
            Entidades.Profissional profissionalCadastrar = new Entidades.Profissional()
            {
                Nome = cadastrarProfissionalDto.Nome,
                Telefone = cadastrarProfissionalDto.Telefone,
                Endereço = cadastrarProfissionalDto.Endereco,
                Ativo = cadastrarProfissionalDto.Ativo
            };

            _contexto.ChangeTracker.Clear();
            _contexto.Profissionals.Add(profissionalCadastrar);
            return _contexto.SaveChanges();
            throw new NotImplementedException();
        }

        public int Excluir(int IdProfissional)
        {
            Entidades.Profissional profissionalExcluir = 
                (from p in _contexto.Profissionals
                 where p.IdProfissional == IdProfissional
                 select p).FirstOrDefault();

            if(profissionalExcluir == null ||
                DBNull.Value.Equals(profissionalExcluir.IdProfissional) ||
                profissionalExcluir.IdProfissional == 0)
            {
                return 0;
            }

            _contexto.ChangeTracker.Clear();
            _contexto.Profissionals.Remove(profissionalExcluir);
            return _contexto.SaveChanges();
            throw new NotImplementedException();
        }

        public List<ProfissionalDto> ListarProfissionais()
        {
            return (from p in _contexto.Profissionals
                    select new Dto.ProfissionalDto()
                    {
                        IdProfissional= p.IdProfissional,
                        Nome= p.Nome,
                        Telefone= p.Telefone,
                        Endereco = p.Endereço,
                        Ativo= p.Ativo
                    }).ToList();
            throw new NotImplementedException();
        }

        public ProfissionalDto ListarProfissionalPorId(int IdProfissional)
        {
            return (from p in _contexto.Profissionals
                    select new Dto.ProfissionalDto()
                    {
                        IdProfissional = p.IdProfissional,
                        Nome = p.Nome,
                        Telefone = p.Telefone,
                        Endereco = p.Endereço,
                        Ativo = p.Ativo
                    })?.FirstOrDefault()
                    ?? new ProfissionalDto();
            throw new NotImplementedException();
        }
    }
}

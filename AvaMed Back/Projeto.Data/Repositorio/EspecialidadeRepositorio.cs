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
    public class EspecialidadeRepositorio : IEspecialidadeRepositorio
    {

        private readonly Contexto.AvamedContext _contexto;

        public EspecialidadeRepositorio (Contexto.AvamedContext contexto)
        {
            _contexto = contexto;
        }

        public int Atualizar(EspecialidadeAtualizarDto atualizarEspecialidade)
        {
            Entidades.Especialidade especialidadeEntidadeBanco =
                (from e in _contexto.Especialidades
                 where e.IdEspecialidade == atualizarEspecialidade.IdEspecialidade
                 select e)
                 .FirstOrDefault();

            if (especialidadeEntidadeBanco == null)
            {
                return 0;
            }

            especialidadeEntidadeBanco.Nome = atualizarEspecialidade.Nome;
            especialidadeEntidadeBanco.Descrição = atualizarEspecialidade.Descrição;
            especialidadeEntidadeBanco.Ativo = atualizarEspecialidade.Ativo;

            return _contexto.SaveChanges();
        }

        public int Cadastrar(EspecialidadeCadastrarDto cadastarEspecialidade)
        {

            Entidades.Especialidade especialidadeEntidade = new Entidades.Especialidade()
            {
                Nome = cadastarEspecialidade.Nome,
                Descrição = cadastarEspecialidade.Descrição,
                Ativo = cadastarEspecialidade.Ativo
            };

            _contexto.ChangeTracker.Clear();
            _contexto.Especialidades.Add(especialidadeEntidade);
            return _contexto.SaveChanges();


            throw new NotImplementedException();
        }

        public int Excluir(int IdEspecialidade)
        {
            Entidades.Especialidade especialidadeEntidade =
                (from e in _contexto.Especialidades
                 where e.IdEspecialidade == IdEspecialidade
                 select e).FirstOrDefault();

            if (especialidadeEntidade == null || DBNull.Value.Equals(especialidadeEntidade.IdEspecialidade) || especialidadeEntidade.IdEspecialidade == 0)
            {
                return 0;
            }

            _contexto.ChangeTracker.Clear();
            _contexto.Especialidades.Remove(especialidadeEntidade);
            return _contexto.SaveChanges();

            throw new NotImplementedException();
        }

        public List<Dto.EspecialidadeDto> ListarEspecialidades()
        {
            return (from e in _contexto.Especialidades
                    select new Dto.EspecialidadeDto()
                    {
                        IdEspecialidade = e.IdEspecialidade,
                        Nome = e.Nome,
                        Descrição = e.Descrição,
                        Ativo = e.Ativo
                    }).ToList();

        }

        public Dto.EspecialidadeDto ListarEspecialidadePorId(int idEspecialidade)
        {
            return (from e in _contexto.Especialidades
                    where e.IdEspecialidade == idEspecialidade
                    select new Dto.EspecialidadeDto()
                    {
                        IdEspecialidade = e.IdEspecialidade,
                        Nome = e.Nome,
                        Descrição = e.Descrição,
                        Ativo = e.Ativo
                    })
                    ?.FirstOrDefault()
                    ?? new EspecialidadeDto();
        }


        
    }

      
    
}

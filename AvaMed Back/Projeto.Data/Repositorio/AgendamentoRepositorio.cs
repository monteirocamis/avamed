using Projeto.Data.Contexto;
using Projeto.Data.Dto;
using Projeto.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Data.Repositorio
{
    public class AgendamentoRepositorio : IAgendamentoRepositorio
    {
        private readonly AvamedContext _contexto;

        public AgendamentoRepositorio(AvamedContext contexto)
        {
            _contexto = contexto;
        }

        public List<AgendamentoDto> ListarAgendamentos()
        {
            return (from a in _contexto.Agendamentos
                    select new Dto.AgendamentoDto()
                    {
                        IdAgendamento = a.IdAgendamento,
                        IdEspecialidade = a.IdEspecialidade,
                        IdProfissional = a.IdProfissional,
                        DataHoraAgendamento = a.DataHoraAgendamento,
                        IdBeneficiario = a.IdBeneficiario,
                        Ativo = a.Ativo
                    }).ToList();
            throw new NotImplementedException();
        }

        public AgendamentoDto ListarAgendamentosPorId(int IdAgendamento)
        {
            return (from a in _contexto.Agendamentos
                    select new Dto.AgendamentoDto()
                    {
                        IdAgendamento = a.IdAgendamento,
                        IdEspecialidade = a.IdEspecialidade,
                        IdProfissional = a.IdProfissional,
                        DataHoraAgendamento = a.DataHoraAgendamento,
                        IdBeneficiario = a.IdBeneficiario,
                        Ativo = a.Ativo
                    })?.FirstOrDefault()
                    ?? new AgendamentoDto();
            throw new NotImplementedException();
        }

        public int Cadastrar(AgendamentoDto cadastrarAgendamentoDto)
        {
            Entidades.Agendamento agendamentoEntidade = new Entidades.Agendamento()
            {
                IdHospital = cadastrarAgendamentoDto.IdHospital,
                IdEspecialidade = cadastrarAgendamentoDto.IdEspecialidade,
                IdProfissional = cadastrarAgendamentoDto.IdProfissional,
                DataHoraAgendamento = cadastrarAgendamentoDto.DataHoraAgendamento,
                IdBeneficiario = cadastrarAgendamentoDto.IdBeneficiario,
                Ativo = cadastrarAgendamentoDto.Ativo
            };

            _contexto.ChangeTracker.Clear();
            _contexto.Agendamentos.Add(agendamentoEntidade);
            return _contexto.SaveChanges();
            throw new NotImplementedException();
        }
        public int Atualizar(AgendamentoDto cadastrarAgendamentoDto)
        {
            Entidades.Agendamento agendamentoEntidadeSalvarBanco = 
                (from a in _contexto.Agendamentos
                 where a.IdAgendamento == cadastrarAgendamentoDto.IdAgendamento
                 select a).FirstOrDefault();

            if(agendamentoEntidadeSalvarBanco == null)
            {
                return 0;
            }

            agendamentoEntidadeSalvarBanco.IdHospital = cadastrarAgendamentoDto.IdHospital;
            agendamentoEntidadeSalvarBanco.IdEspecialidade = cadastrarAgendamentoDto.IdEspecialidade;
            agendamentoEntidadeSalvarBanco.IdProfissional = cadastrarAgendamentoDto.IdProfissional;
            agendamentoEntidadeSalvarBanco.DataHoraAgendamento = cadastrarAgendamentoDto.DataHoraAgendamento;
            agendamentoEntidadeSalvarBanco.IdBeneficiario = cadastrarAgendamentoDto.IdBeneficiario;
            agendamentoEntidadeSalvarBanco.Ativo = cadastrarAgendamentoDto.Ativo;

            return _contexto.SaveChanges();
            throw new NotImplementedException();
        }

        public int Excluir(int IdAgendamento)
        {
            Entidades.Agendamento agendamentoExcluirBanco = 
                (from a in _contexto.Agendamentos
                 where a.IdAgendamento == IdAgendamento
                 select a).FirstOrDefault();

            if(agendamentoExcluirBanco== null || DBNull.Value.Equals(agendamentoExcluirBanco.IdAgendamento) || agendamentoExcluirBanco.IdAgendamento == 0)
            {
                return 0;
            }

            _contexto.ChangeTracker.Clear();
            _contexto.Agendamentos.Remove(agendamentoExcluirBanco);
            return _contexto.SaveChanges();
            throw new NotImplementedException();
        }
    }
}

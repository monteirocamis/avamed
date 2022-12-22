export interface IAgendamento {
  IdAgendamento: number,
  IdHospital: number,
  IdEspecialidade: number,
  IdProfissional: number,
  DataHoraAgendamento: Date,
  IdBeneficiario: number,
  Ativo: boolean
}

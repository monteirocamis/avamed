import { ResultadoProfissionaisComponent } from './resultado-profissionais/resultado-profissionais.component';
import { ResultadoAgendamentoComponent } from './resultado-agendamento/resultado-agendamento.component';
import { HospitalComponent } from './hospital/hospital.component';
import { CadastroProfissionalComponent } from './cadastro-profissional/cadastro-profissional.component';
import { CadastroEspecialidadeComponent } from './cadastro-especialidade/cadastro-especialidade.component';
import { AgendamentoComponent } from './agendamento/agendamento.component';
import { BeneficiariosComponent } from './beneficiarios/beneficiarios.component';
import { HomeComponent } from './home/home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {path: 'home' , component: HomeComponent},
  {path: 'beneficiario' , component: BeneficiariosComponent},
  {path: 'agendamento' , component: AgendamentoComponent},
  {path: 'cadastro-especialidade' , component: CadastroEspecialidadeComponent},
  {path: 'cadastro-profissional' , component: CadastroProfissionalComponent},
  {path: 'hospital' , component: HospitalComponent},
  {path: 'resultado-agendamento' , component: ResultadoAgendamentoComponent},
  {path: 'resultado-profissionais' , component: ResultadoProfissionaisComponent},
  {path: '**' , redirectTo:'home'} // url desconhecida
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

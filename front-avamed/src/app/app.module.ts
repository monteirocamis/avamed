import { NavigationService } from 'src/app/services/navigation.service';

import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BeneficiariosComponent } from './components/beneficiarios/beneficiarios.component';
import { HeaderComponent } from './components/header/header.component';
import { HomeComponent } from './components/home/home.component';
import { AgendamentoComponent } from './components/agendamento/agendamento.component';
import { HospitalComponent } from './components/hospital/hospital.component';
import { CadastroProfissionalComponent } from './components/cadastro-profissional/cadastro-profissional.component';
import { CadastroEspecialidadeComponent } from './components/cadastro-especialidade/cadastro-especialidade.component';
import { ResultadoAgendamentoComponent } from './components/resultado-agendamento/resultado-agendamento.component';
import { ResultadoProfissionaisComponent } from './components/resultado-profissionais/resultado-profissionais.component';


@NgModule({
  declarations: [
    AppComponent,
    BeneficiariosComponent,
    HeaderComponent,
    HomeComponent,
    AgendamentoComponent,
    HospitalComponent,
    CadastroProfissionalComponent,
    CadastroEspecialidadeComponent,
    ResultadoAgendamentoComponent,
    ResultadoProfissionaisComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    BrowserAnimationsModule
  ],
  providers: [NavigationService],
  bootstrap: [AppComponent]
})
export class AppModule { }

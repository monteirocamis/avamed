import { NavigationService } from './services/navigation.service';
import { BeneficiariosComponent } from './beneficiarios/beneficiarios.component';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import {MatDialogModule} from '@angular/material/dialog';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component';
import { AgendamentoComponent } from './agendamento/agendamento.component';
import { HospitalComponent } from './hospital/hospital.component';
import { CadastroProfissionalComponent } from './cadastro-profissional/cadastro-profissional.component';
import { CadastroEspecialidadeComponent } from './cadastro-especialidade/cadastro-especialidade.component';
import { ResultadoAgendamentoComponent } from './resultado-agendamento/resultado-agendamento.component';
import { ResultadoProfissionaisComponent } from './resultado-profissionais/resultado-profissionais.component';

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
    BrowserAnimationsModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [NavigationService , HttpClient],
  bootstrap: [AppComponent]
})
export class AppModule { }

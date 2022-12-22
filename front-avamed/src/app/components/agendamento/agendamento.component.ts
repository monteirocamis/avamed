import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-agendamento',
  templateUrl: './agendamento.component.html',
  styleUrls: ['./agendamento.component.css']
})
export class AgendamentoComponent {
  navigateResultadoAgendamento(){
    this.router.navigate(['resultado-agendamento'])
  }
  constructor(private router: Router ){

  }
}

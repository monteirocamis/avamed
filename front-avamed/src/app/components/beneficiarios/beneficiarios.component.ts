import { Router  } from '@angular/router';
import { Component } from '@angular/core';

@Component({
  selector: 'app-beneficiarios',
  templateUrl: './beneficiarios.component.html',
  styleUrls: ['./beneficiarios.component.css']
})
export class BeneficiariosComponent {
  navigateAgendamento(){
    this.router.navigate(['agendamento'])
  }
  constructor(private router: Router ){

  }
}

import { Component } from '@angular/core';
import { Router  } from '@angular/router';

@Component({
  selector: 'app-hospital',
  templateUrl: './hospital.component.html',
  styleUrls: ['./hospital.component.css']
})
export class HospitalComponent {
  navigateProfissional(){
    this.router.navigate(['cadastro-profissional'])
  }
  constructor (private router: Router ){

  }

}

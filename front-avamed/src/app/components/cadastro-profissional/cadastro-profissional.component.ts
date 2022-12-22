import { Component } from '@angular/core';
import { Router  } from '@angular/router';

@Component({
  selector: 'app-cadastro-profissional',
  templateUrl: './cadastro-profissional.component.html',
  styleUrls: ['./cadastro-profissional.component.css']
})
export class CadastroProfissionalComponent {
  navigateEspecialidade(){
    this.router.navigate(['cadastro-especialidade'])
  }
  constructor(private router: Router ){

  }


}

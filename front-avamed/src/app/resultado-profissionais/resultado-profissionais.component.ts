import { IProfissionalDto } from './../../interfaces/IProfissionalDto';

import { Component, OnInit, Input } from '@angular/core';
import { Router  } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { CrudService } from 'src/app/services/crud.service';

@Component({
  selector: 'app-resultado-profissionais',
  templateUrl: './resultado-profissionais.component.html',
  styleUrls: ['./resultado-profissionais.component.css']
})
export class ResultadoProfissionaisComponent implements OnInit{

  @Input() Profissional!: IProfissionalDto;
  public listaDeProfissionais: any;

  navigateEspecialidade(){
    this.router.navigate(['cadastro-especialidade'])
  }

  constructor(private router: Router, private serviceListarProfissionais: CrudService ){

    }

    ngOnInit(): void {
      this.serviceListarProfissionais.getProfissional().subscribe(data => {
        this.listaDeProfissionais = data;
        console.log(data)
      });
    }


}

import { CrudService } from './../service/crud.service';
import { Component, OnInit, Input } from '@angular/core';
import { Router  } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { IProfissionalDto } from '../interfaces/IProfissionalDto';

@Component({
  selector: 'app-cadastro-profissional',
  templateUrl: './cadastro-profissional.component.html',
  styleUrls: ['./cadastro-profissional.component.css']
})



export class CadastroProfissionalComponent implements OnInit{
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

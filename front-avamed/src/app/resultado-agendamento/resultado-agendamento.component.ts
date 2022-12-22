import { Dados } from './../models/placeholder.model';
import { CrudService } from './../services/crud.service';
import { Router } from '@angular/router';
import { Component , OnInit } from '@angular/core';

@Component({
  selector: 'app-resultado-agendamento',
  templateUrl: './resultado-agendamento.component.html',
  styleUrls: ['./resultado-agendamento.component.css']
})
export class ResultadoAgendamentoComponent implements OnInit{
    dados : any;
    erro: any;

  constructor(private router: Router , private crudService: CrudService ){
    this.getter
  }


  ngOnInit() { }

    getter() {
      this.crudService.getDados().subscribe((data: Dados) => {
        this.dados = data;
        console.log(this.dados);
        console.log(data);
        } , (error: any) => {
          this.erro = error;
          console.error( error)
        });
    }
}

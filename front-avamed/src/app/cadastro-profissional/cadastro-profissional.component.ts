import { CrudService } from './../service/crud.service';
import { Component, OnInit, Input } from '@angular/core';
import { Router  } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { IProfissionalDto } from '../interfaces/IProfissionalDto';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-cadastro-profissional',
  templateUrl: './cadastro-profissional.component.html',
  styleUrls: ['./cadastro-profissional.component.css']
})



export class CadastroProfissionalComponent implements OnInit{
  @Input() Profissional!: IProfissionalDto;
  public listaDeProfissionais: any;
  public profissionalForm!: FormGroup;
  navigateEspecialidade(){
    this.router.navigate(['cadastro-especialidade'])
  }
  constructor(private router: Router, private crudProfissionais: CrudService ){

    }

    ngOnInit(): void {
      this.crudProfissionais.getProfissional().subscribe(data => {
        this.listaDeProfissionais = data;
        console.log(data)
      });

      this.buildForm();
    }

    public buildForm(){
      this.profissionalForm = new FormGroup({
        nome: new FormControl(''),
        telefone: new FormControl(''),
        endereco: new FormControl(''),
        ativo: new FormControl(true)
      });
    }

    public submitCadastro(){
      console.log(this.profissionalForm.value)
      this.crudProfissionais.postProfissional(this.profissionalForm.value).subscribe(()=>{
        console.log("Enviado com sucesso");
    });
    }


}

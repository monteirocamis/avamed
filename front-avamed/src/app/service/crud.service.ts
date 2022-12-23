import { IProfissionalDto } from './../interfaces/IProfissionalDto';
import { Injectable } from '@angular/core';
import { catchError, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CrudService {


constructor(private http: HttpClient) {
}

  public getProfissional(): Observable<any>{


    return this.http.get(`https://127.0.0.1:7042/ListarProfissionais`)
    // return this.http.get(`https://pokeapi.co/api/v2/pokemon?limit=151`)
    //return this.http.get(`https://pokeapi.co/api/v2/pokemon?limit=151`)
  }

  public postProfissional(data: IProfissionalDto ): Observable<any> {
   return this.http.post(`https://127.0.0.1:7042/CadastrarProfissional`, data)

  }

}

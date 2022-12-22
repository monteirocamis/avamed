import { Dados } from './../models/placeholder.model';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class CrudService {



  constructor(private http: HttpClient) { }

  public getDados(): Observable<any> {
    return this.http.get(`https://localhost:7042/ListarAgendamentos`)
  }
}

import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Grupo } from '../models/grupos';

@Injectable({
  providedIn: 'root'
})
export class GrupoService {
  
  private url = `${environment.ApiUrl}GrupoVeiculo`

  constructor(private http: HttpClient) {

   }

   GetGrupos() : Observable<Grupo[]>{
    return this.http.get<Grupo[]>(this.url);
  }
}

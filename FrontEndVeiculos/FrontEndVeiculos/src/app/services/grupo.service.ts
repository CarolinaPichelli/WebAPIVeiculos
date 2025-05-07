import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Grupo } from '../models/grupos';
 
@Injectable({
  providedIn: 'root'
})
export class GrupoService {
 
  private url = `${environment.ApiUrl}GrupoVeiculo`;
 
  constructor(private http: HttpClient) { }
 
  //endpoint para obter todos os veiculos
  GetGrupos() : Observable<Grupo[]> {
   return this.http.get<Grupo[]>(this.url);
  }
 
  GetGrupoById(id: number) : Observable<Grupo> {
    return this.http.get<Grupo>(`${this.url}/${id}`);
  }
 
  CreateGrupo(grupo: Grupo) : Observable<Grupo[]> {
    return this.http.post<Grupo[]>(this.url, grupo);
  }
 
  UpdateGrupo(id: number, grupo: Grupo): Observable<Grupo> {
    return this.http.put<Grupo>(`${this.url}/${id}`, grupo);
  }
 
  DeleteGrupo(id: number): Observable<Grupo[]>{
    return this.http.delete<Grupo[]>(`${this.url}/${id}`);}
 
 
}
 
 

import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Empresa } from '../models/empresas';

@Injectable({
  providedIn: 'root'
})
export class EmpresaService {
 
  private url = `${environment.ApiUrl}EmpresaAssistencia`

  constructor(private http: HttpClient) {

   }

   GetEmpresas() : Observable<Empresa[]>{
    return this.http.get<Empresa[]>(this.url);
  }

  CreateEmpresa(empresa: Empresa): Observable<Empresa[]> {
    return this.http.post<Empresa[]>(`${this.url}`, empresa);
  }

  GetEmpresaById(id: number) : Observable<Empresa> {
    return this.http.get<Empresa>(`${this.url}/${id}`);
  }

  UpdateEmpresa(id: number, empresa: Empresa): Observable<Empresa> {
    return this.http.put<Empresa>(`${this.url}/${id}`, empresa);
  }

  DeleteEmpresa(id: number): Observable<Empresa[]> {
    // Usando path parameter para identificar a empresa
    return this.http.delete<Empresa[]>(`${this.url}/${id}`);
  }
}


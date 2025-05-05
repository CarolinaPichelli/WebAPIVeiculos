import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
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
}

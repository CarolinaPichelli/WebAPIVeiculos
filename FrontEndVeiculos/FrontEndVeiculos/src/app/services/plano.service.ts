import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Plano } from '../models/planos';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PlanoService {

  private url = `${environment.ApiUrl}PlanoAssistencia`

  constructor(private http: HttpClient) {

   }

   GetPlanos() : Observable<Plano[]>{
    return this.http.get<Plano[]>(this.url);
  }
}

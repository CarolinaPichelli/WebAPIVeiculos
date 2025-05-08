import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Assistencia } from '../models/assistencias';


@Injectable({
  providedIn: 'root'
})
export class AssistenciaService {

  private url = `${environment.ApiUrl}VeiculoAssistencia`

  constructor(private http: HttpClient) { }

  GetAssistencias() : Observable<Assistencia[]>{
    return this.http.get<Assistencia[]>(this.url);
  }

  CreateAssistencia(assistencia: Assistencia): Observable<Assistencia[]> {
    return this.http.post<Assistencia[]>(`${this.url}`, assistencia);
  }

  GetAssistenciaById(id: number) : Observable<Assistencia> {
    return this.http.get<Assistencia>(`${this.url}/${id}`);
  }

  UpdateAssistencia(id: number, assistencia: Assistencia): Observable<Assistencia> {
    return this.http.put<Assistencia>(`${this.url}/${id}`, assistencia);
  }

  DeleteAssistencia(id: number): Observable<Assistencia[]> {
    return this.http.delete<Assistencia[]>(`${this.url}/${id}`);
  }
}



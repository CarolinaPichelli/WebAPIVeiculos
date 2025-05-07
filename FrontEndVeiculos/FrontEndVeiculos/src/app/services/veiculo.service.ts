import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Veiculo } from '../models/veiculos';

@Injectable({
  providedIn: 'root'
})
export class VeiculoService {

  private url = `${environment.ApiUrl}Veiculo`

  constructor(private http: HttpClient) {}

  GetVeiculos() : Observable<Veiculo[]>{
    return this.http.get<Veiculo[]>(this.url);
  }

  CreateVeiculo(veiculo: Veiculo): Observable<Veiculo[]> {
    return this.http.post<Veiculo[]>(`${this.url}`, veiculo);
  }

  GetVeiculoById(id: number) : Observable<Veiculo> {
    return this.http.get<Veiculo>(`${this.url}/${id}`);
  }

  UpdateVeiculo(id: number, veiculo: Veiculo): Observable<Veiculo> {
    return this.http.put<Veiculo>(`${this.url}/${id}`, veiculo);
  }

  DeleteVeiculo(id: number): Observable<Veiculo[]> {
    // Usando path parameter para identificar o veículo
    return this.http.delete<Veiculo[]>(`${this.url}/${id}`);
  }
}

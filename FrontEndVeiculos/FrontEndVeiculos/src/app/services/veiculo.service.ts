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

  constructor(private http: HttpClient) {

   }

   GetVeiculos() : Observable<Veiculo[]>{
    return this.http.get<Veiculo[]>(this.url);
  }
}

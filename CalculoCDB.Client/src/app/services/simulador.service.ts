import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { SimulacaoResponse } from '../interfaces/simulacao-response';
import { SimulacaoRequest } from '../interfaces/simulacao-request';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SimuladorService {
  apiUrl = environment.CDB_API_URL

  constructor(private readonly http: HttpClient) { }

  calcular(request: SimulacaoRequest): Observable<SimulacaoResponse> {
    return this.http.get<SimulacaoResponse>(`${this.apiUrl}/calcular`, {
      params: {
        vlInicial: request.vlInicial, 
        qtdMeses: request.qtdMeses
      }
    })
  }
}

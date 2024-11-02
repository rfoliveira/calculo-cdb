import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { SimulacaoResponse } from '../interfaces/simulacao-response';
import { SimulacaoRequest } from '../interfaces/simulacao-request';

@Injectable({
  providedIn: 'root'
})
export class SimuladorService {
  
  constructor(private readonly http: HttpClient) { }

  calcular(request: SimulacaoRequest) {
    let retorno: SimulacaoResponse = { vlBruto: 0, vlLiquido: 0}

    this.http.get<SimulacaoResponse>(`${environment.CDB_API_URL}/calcular`, {
      params: {
        vlInicial: request.vlInicial, 
        qtdMeses: request.qtdMeses
      }
    }).subscribe(res  => {
      console.log('Retorno da api:', res)
      retorno = {...res}
    })
    
    return retorno
  }
}

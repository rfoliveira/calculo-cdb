import { TestBed } from '@angular/core/testing';

import { SimuladorService } from './simulador.service';
import { HttpClient } from '@angular/common/http';
import { SimulacaoRequest } from '../interfaces/simulacao-request';

describe('SimuladorService', () => {
  let service: SimuladorService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SimuladorService, HttpClient]
    })
  })

  it('should have url defined', () => {
    service = TestBed.inject(SimuladorService)
    expect(service.apiUrl).not.toBeNull()
  })

  it('should return positive values', () => {
    service = TestBed.inject(SimuladorService)
    const fakeRequest: SimulacaoRequest = {
      vlInicial: 1000,
      qtdMeses: 10
    }
    service.calcular(fakeRequest).subscribe(res => {
      const {vlLiquido, vlBruto } = res
      
      expect(vlLiquido).toBeGreaterThan(0)
      expect(vlBruto).toBeGreaterThan(0)
    })    
  })
});

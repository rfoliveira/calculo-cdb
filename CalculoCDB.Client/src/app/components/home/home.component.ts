import { Component } from '@angular/core';
import { SimuladorService } from '../../services/simulador.service';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterOutlet } from '@angular/router';
import { CDBResultComponent } from '../cdbresult/cdbresult.component';
import { SimulacaoResponse } from '../../interfaces/simulacao-response';
import { SimulacaoRequest } from '../../interfaces/simulacao-request';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    RouterOutlet,
    ReactiveFormsModule,
    CDBResultComponent
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  cdbForm = new FormGroup({
    vlInicial: new FormControl(0, [Validators.required]),
    qtdMeses: new FormControl(0, [Validators.required, Validators.min(1)])
  })
  showResults: boolean = false
  cdbResult: SimulacaoResponse = {vlBruto: 0, vlLiquido: 0}

  constructor(private readonly service: SimuladorService) { }
    
  simular() {
    const { vlInicial, qtdMeses } = this.cdbForm.value
    const payload: SimulacaoRequest = {
      vlInicial: vlInicial!,
      qtdMeses: qtdMeses!
    }

    this.cdbResult = {...this.service.calcular(payload)}
    this.showResults = true
  }

  limpar() {
    this.cdbForm.setValue({vlInicial: 0, qtdMeses: 0})
    this.showResults = false
  }
}

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
    vlInicial: new FormControl(null, [Validators.required]),
    qtdMeses: new FormControl(null, [Validators.required, Validators.min(1)])
  })
  showResults: boolean = false
  cdbResult: SimulacaoResponse = {VlBruto: 0, VlLiquido: 0}  

  constructor(private readonly service: SimuladorService) { }
    
  simular() {
    const { vlInicial, qtdMeses } = this.cdbForm.value
    const payload: SimulacaoRequest = {
      vlInicial: vlInicial!,
      qtdMeses: qtdMeses!
    }

    this.service.calcular(payload).subscribe(res => {
        console.log('retorno do service', res)
        this.cdbResult = {...res}
        console.log('this.cdbResult', this.cdbResult)
    })
    this.showResults = true
  }

  limpar() {
    this.cdbForm.setValue({vlInicial: null, qtdMeses: null})
    this.showResults = false
  }
}

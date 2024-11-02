import { Component, Input } from '@angular/core';
import { SimulacaoResponse } from '../../interfaces/simulacao-response';

@Component({
  selector: 'app-cdbresult',
  standalone: true,
  imports: [],
  templateUrl: './cdbresult.component.html',
  styleUrl: './cdbresult.component.css'
})
export class CDBResultComponent {
  @Input() result!: SimulacaoResponse;
}

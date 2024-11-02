import { Component, Input } from '@angular/core';
import { SimulacaoResponse } from '../../interfaces/simulacao-response';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-cdbresult',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './cdbresult.component.html',
  styleUrl: './cdbresult.component.css'
})
export class CDBResultComponent {
  @Input() result!: SimulacaoResponse;
}

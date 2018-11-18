import { Component, OnInit, Input } from '@angular/core';
import { Cash } from 'src/app/shared/running-state.model';
import { StateMonitorService } from '../../shared/state-monitor.service'


@Component({
  selector: 'app-input-panel',
  templateUrl: './input-panel.component.html',
  styleUrls: ['./input-panel.component.scss']
})
export class InputPanelComponent implements OnInit {
  cashList: Cash[];
  @Input() priceToPay: number;
  amountReceived: number;
  constructor(private stateService: StateMonitorService) { }

  ngOnInit() {
  }

  isInputEnough(): boolean {
    return !(this.amountReceived < this.priceToPay);
  }

  onReceiveMoney(amount: number) {
    this.amountReceived += amount;
  }

}

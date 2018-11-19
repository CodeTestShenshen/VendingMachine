import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Cash } from 'src/app/shared/running-state.model';
import { StateMonitorService } from '../../shared/state-monitor.service';


@Component({
  selector: 'app-input-panel',
  templateUrl: './input-panel.component.html',
  styleUrls: ['./input-panel.component.scss']
})
export class InputPanelComponent implements OnInit {

  @Output() receiveCash: EventEmitter<number> = new EventEmitter<number>();

  // amount in cents
  amountReceived = 0;
  constructor(private stateService: StateMonitorService) { }

  ngOnInit() {
  }

  onReceiveMoney(amount: number) {
    this.amountReceived += amount;
  }

  getCashList(): Cash[] {
    return this.stateService.getCashState();
  }
  sumInputCash(cash: Cash) {
    this.amountReceived += cash.unit;
    this.receiveCash.emit(this.amountReceived);
    this.stateService.updateCashState(cash);
  }
}

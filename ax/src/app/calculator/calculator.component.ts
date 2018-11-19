import { Component, OnInit, Input } from '@angular/core';
import { Cash } from '../shared/running-state.model';
import { StateMonitorService } from '../shared/state-monitor.service';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.scss']
})
export class CalculatorComponent implements OnInit {
  @Input() itemPrice = 0;
  receivedCash = 0;
  changeResult: Cash[] = [];
  noEnoughtChange = false;

  constructor(private cashStateService: StateMonitorService) { }


  ngOnInit() {
  }

  get itemPriceDisplay(): string {
    return '$' + (this.itemPrice / 100).toFixed(2);
  }

  get receivedCashDisplay(): string {
    return '$' + (this.receivedCash / 100).toFixed(2);
  }

  onReceivedCash(amount: number) {
    this.receivedCash = amount;
  }
  calculateChange() {
    const changeAmount = this.receivedCash - this.itemPrice;
    this.changeResult = this.cashStateService.calculateChanges(changeAmount); // need async

    if (this.changeResult) {
      alert('can not give cash back!');
    }

  }
}


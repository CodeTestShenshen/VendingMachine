import { Component, OnInit, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';
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

  testValue = 0;
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

  getCashList(): Cash[] {
    return this.cashStateService.getCashState();
  }

  calculateChangeTest() {
    this.cashStateService.calculateChanges(this.testValue * 100); // need async
  }
}


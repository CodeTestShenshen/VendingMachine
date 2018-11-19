import { Component, OnInit, Input } from '@angular/core';
import { Cash } from 'src/app/shared/running-state.model';
import { StateMonitorService } from '../../shared/state-monitor.service'


@Component({
  selector: 'app-input-panel',
  templateUrl: './input-panel.component.html',
  styleUrls: ['./input-panel.component.scss']
})
export class InputPanelComponent implements OnInit {
  public cashList: Cash[] = [
    { cashType: 'c5', unit: 5, displayName: '5 cents', quantity: 0 },
    { cashType: 'c10', unit: 10, displayName: '10 cents', quantity: 0 },
    { cashType: 'c20', unit: 20, displayName: '20 cents', quantity: 0 },
    { cashType: 'c50', unit: 50, displayName: '50 cents', quantity: 0 },
    { cashType: 'Aud1', unit: 100, displayName: '1 dollor', quantity: 0 },
    { cashType: 'Aud2', unit: 200, displayName: '2 dollor', quantity: 0 },
    { cashType: 'Aud5', unit: 500, displayName: '5 dollor', quantity: 0 },
    { cashType: 'Aud10', unit: 1000, displayName: '10 dollor', quantity: 0 },
    { cashType: 'Aud20', unit: 2000, displayName: '20 dollor', quantity: 0 },
    { cashType: 'Aud50', unit: 5000, displayName: '50 dollor', quantity: 0 }
  ];


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

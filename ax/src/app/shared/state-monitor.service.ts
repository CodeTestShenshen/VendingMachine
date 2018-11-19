import { Injectable } from '@angular/core';
import { CashStates, Cash } from './running-state.model';

@Injectable({
  providedIn: 'root'
})
export class StateMonitorService {

  private cashState: Cash[] = [
    { cashType: 'c5', unit: 5, displayName: '5 cents', quantity: 10 },
    { cashType: 'c10', unit: 10, displayName: '10 cents', quantity: 20 },
    { cashType: 'c20', unit: 20, displayName: '20 cents', quantity: 30 },
    { cashType: 'c50', unit: 50, displayName: '50 cents', quantity: 20 },
    { cashType: 'Aud1', unit: 100, displayName: '1 dollor', quantity: 10 },
    { cashType: 'Aud2', unit: 200, displayName: '2 dollor', quantity: 20 },
    { cashType: 'Aud5', unit: 500, displayName: '5 dollor', quantity: 30 },
    { cashType: 'Aud10', unit: 1000, displayName: '10 dollor', quantity: 110 },
    { cashType: 'Aud20', unit: 2000, displayName: '20 dollor', quantity: 220 },
    { cashType: 'Aud50', unit: 5000, displayName: '50 dollor', quantity: 10 }
  ];


  constructor() {
  }

  public updateCashState(c: Cash) {

  }

  public getCashState(): Cash[] {
    return this.cashState;
  }

  public calculateChanges(changeAmount: number): Cash[] {
    return [
      { cashType: 'c5', unit: 5, displayName: '5 cents', quantity: 3 },
      { cashType: 'c10', unit: 10, displayName: '10 cents', quantity: 4 },
      { cashType: 'c20', unit: 20, displayName: '20 cents', quantity: 5 }];
  }
}

import { Injectable } from '@angular/core';
import { CashStates, Cash } from './running-state.model';

@Injectable({
  providedIn: 'root'
})
export class StateMonitorService {

  private cashState: Cash[] = [
    { cashType: 'c5', unit: 5, displayName: '5 cents', quantity: 100 },
    { cashType: 'c10', unit: 10, displayName: '10 cents', quantity: 100 },
    { cashType: 'c20', unit: 20, displayName: '20 cents', quantity: 100 },
    { cashType: 'c50', unit: 50, displayName: '50 cents', quantity: 100 },
    { cashType: 'Aud1', unit: 100, displayName: '1 dollor', quantity: 100 },
    { cashType: 'Aud2', unit: 200, displayName: '2 dollor', quantity: 100 },
    { cashType: 'Aud5', unit: 500, displayName: '5 dollor', quantity: 100 },
    { cashType: 'Aud10', unit: 1000, displayName: '10 dollor', quantity: 100 },
    { cashType: 'Aud20', unit: 2000, displayName: '20 dollor', quantity: 100 },
    { cashType: 'Aud50', unit: 5000, displayName: '50 dollor', quantity: 100 }
  ];


  constructor() {
  }



  public getCashState(): Cash[] {
    return this.cashState;
  }

  public updateCashState(changes: Cash[]) {
    for (let c of changes) {
      let index = this.cashState.findIndex(x => x.cashType === c.cashType);
      if (index !== -1) {
        this.cashState[index].quantity = this.cashState[index].quantity + c.quantity;
      }
    }
  }

  public calculateChanges(money: number): Cash[] {
    let cashReturned: Cash[] = [];
    if (this.makeChange(this.cashState, money, 0, cashReturned)) {
      this.updateCashState(cashReturned);
      return cashReturned;
    }
    alert('No enough change to return!');
    return null;
  }

  // the cash should be ordered in asc order and the calculate will start from the last item
  public makeChange(cashes: Cash[], money: number, cashIndex: number, cashReturned: Cash[]): boolean {
    if (money === 0) {
      // change has been resolved
      console.log('get final changes');
      return true;
    }

    if (cashIndex >= cashes.length) {
      return false;
    }
    const key = 'current money ' + money + '-coin ' + cashes[cashIndex].unit;

    let amountOfCash = 0;

    // how many change used so far
    let currentCashNumber = 0;

    while (amountOfCash <= money && currentCashNumber <= cashes[cashIndex].quantity) {
      const remainedMoney = money - amountOfCash;

      if (this.makeChange(cashes, remainedMoney, cashIndex + 1, cashReturned)) {
        // the path is successful, pop up all path verteies
        console.log(key + ' = ' + currentCashNumber + ': left=>' + remainedMoney + ' amount of coin => ' + amountOfCash);
        cashReturned
          .push({
            cashType: cashes[cashIndex].cashType,
            unit: cashes[cashIndex].unit,
            displayName: cashes[cashIndex].displayName,
            quantity: (-1) * currentCashNumber
          });

        return true;
      }

      // update conditions
      amountOfCash += cashes[cashIndex].unit;
      currentCashNumber++;
    }

    return false;
  }
}





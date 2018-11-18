import { Injectable } from '@angular/core';
import { CashStates } from './running-state.model';

@Injectable({
  providedIn: 'root'
})
export class StateMonitorService {

  public cashState: CashStates;
  constructor() {
  }
}

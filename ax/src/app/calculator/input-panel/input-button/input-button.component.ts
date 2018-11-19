import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Cash } from '../../../shared/running-state.model';

@Component({
  selector: 'app-input-button',
  templateUrl: './input-button.component.html',
  styleUrls: ['./input-button.component.scss']
})
export class InputButtonComponent implements OnInit {
  @Input() cash: Cash;
  @Input() disabled = false;
  @Output() insertCash: EventEmitter<Cash> = new EventEmitter<Cash>();
  constructor() { }
  onMoneySelect() {
    this.insertCash.emit(this.cash);
  }

  isEnabled(): boolean {
    return (this.cash.quantity > 0 && !this.disabled);
  }
  ngOnInit() {
  }

  getCashDispayValue(): string {
    if (this.cash) {
      return '$' + (this.cash.unit / 100).toFixed(2);
    }
    return '$0.00';
  }

  getButtonClass(): string {
    if (this.cash) {
      return this.cash.quantity > 0 ? 'btn btn-primary' : 'btn btn-secondary';
    }
    return 'btn btn-secondary';
  }

  IsAvaible(): boolean {
    return this.isEnabled && this.cash.quantity > 0;
  }

  onInsertCash() {
    this.insertCash.emit(this.cash);
    console.log('cash is inserted: ');
    console.log(this.cash);
  }

}

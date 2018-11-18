import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Cash } from '../../../shared/running-state.model';

@Component({
  selector: 'app-input-button',
  templateUrl: './input-button.component.html',
  styleUrls: ['./input-button.component.scss']
})
export class InputButtonComponent implements OnInit {
  @Input() cash: Cash = new Cash();
  @Input() disabled = false;
  @Output() moneySelect: EventEmitter<number> = new EventEmitter<number>();
  constructor() { }
  onMoneySelect() {
    this.moneySelect.emit(this.cash.unit);
  }

  isEnabled(): boolean {
    return (this.cash.quantity > 0 && !this.disabled);
  }
  ngOnInit() {
  }

}

import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Flavour } from 'src/app/shared/flavour.model';

@Component({
  selector: 'app-flavour',
  templateUrl: './flavour.component.html',
  styleUrls: ['./flavour.component.scss']
})
export class FlavourComponent implements OnInit {

  @Input() flavour: Flavour;
  @Output() selectFlavour: EventEmitter<Flavour> = new EventEmitter<Flavour>();
  constructor() { }

  ngOnInit() {
  }

  OnSelectFlavour() {

    this.selectFlavour.emit(this.flavour);
  }

  get flavourPriceDisplay(): string {
    return (this.flavour.PriceInCents / 100).toFixed(2);
  }

}

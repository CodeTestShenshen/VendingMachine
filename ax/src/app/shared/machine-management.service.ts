import { Injectable } from '@angular/core';
import { Flavour } from './flavour.model';
@Injectable({
  providedIn: 'root'
})
export class MachineManagementService {
  flavours: Flavour[] = [
    { SeriesNumber: '1234', PriceInCents: 1800, Name: 'Flavour one' },
    { SeriesNumber: '3214', PriceInCents: 3200, Name: 'Flavour two' },
    { SeriesNumber: '5214', PriceInCents: 11800, Name: 'Flavour three' },
  ];
  constructor() { }
}

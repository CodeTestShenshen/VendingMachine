import { Component, OnInit } from '@angular/core';
import { MachineManagementService } from '../shared/machine-management.service';
import { Flavour } from '../shared/flavour.model';

@Component({
  selector: 'app-flavour-panel',
  templateUrl: './flavour-panel.component.html',
  styleUrls: ['./flavour-panel.component.scss']
})
export class FlavourPanelComponent implements OnInit {

  constructor(private managementService: MachineManagementService) { }

  ngOnInit() {
  }

  get flavourList(): Flavour[] {
    return this.managementService.getFlavours();
  }
}

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CalculatorComponent } from './calculator/calculator.component';
import { InputPanelComponent } from './calculator/input-panel/input-panel.component';
import { InputButtonComponent } from './calculator/input-panel/input-button/input-button.component';

@NgModule({
  declarations: [
    AppComponent,
    CalculatorComponent,
    InputPanelComponent,
    InputButtonComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

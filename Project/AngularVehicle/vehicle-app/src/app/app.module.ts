import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule }    from '@angular/common/http'

import { AppComponent } from './app.component';
import { VehiclemakesComponent } from './vehiclemakes/vehiclemakes.component';
import { VehiclemakeDetailComponent } from './vehiclemake-detail/vehiclemake-detail.component';
import { MessagesComponent } from './messages/messages.component';
import {VehicleMakeService} from "./vehiclemake.service"
@NgModule({
  declarations: [
    AppComponent,
    VehiclemakesComponent,
    VehiclemakeDetailComponent,
    MessagesComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [VehicleMakeService],
  bootstrap: [AppComponent]
})
export class AppModule { }

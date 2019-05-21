import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule }    from '@angular/common/http'

import { AppComponent } from './app.component';
import { VehiclemakesComponent } from './vehiclemakes/vehiclemakes.component';
import { VehiclemakeDetailComponent } from './vehiclemake-detail/vehiclemake-detail.component';
import { MessagesComponent } from './messages/messages.component';
import {VehicleMakeService} from "./vehiclemake.service"
import { AppRoutingModule } from './app-routing.module';
import { VehiclemodelsComponent } from './vehiclemodels/vehiclemodels.component';
import { VehiclemodelDetailComponent } from './vehiclemodel-detail/vehiclemodel-detail.component';
@NgModule({
  declarations: [
    AppComponent,
    VehiclemakesComponent,
    VehiclemakeDetailComponent,
    MessagesComponent,
    VehiclemodelsComponent,
    VehiclemodelDetailComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [VehicleMakeService],
  bootstrap: [AppComponent]
})
export class AppModule { }

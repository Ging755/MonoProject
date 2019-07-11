import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {HttpClientModule} from "@angular/common/http"

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { VehicleMakesComponent } from './Components/vehicle-makes/vehicle-makes.component';
import { PaggingComponent } from './Components/pagging/pagging.component';
import { VehicleMakeDetailComponent } from './Components/vehicle-makes/vehicle-make-detail/vehicle-make-detail.component';
import { VehicleMakeCreateComponent } from './Components/vehicle-makes/vehicle-make-create/vehicle-make-create.component';
import { VehicleModelsComponent } from './Components/vehicle-models/vehicle-models.component';
import { VehicleModelCreateComponent } from './Components/vehicle-models/vehicle-model-create/vehicle-model-create.component';
import { VehicleModelDetailsComponent } from './Components/vehicle-models/vehicle-model-details/vehicle-model-details.component';

@NgModule({
  declarations: [
    AppComponent,
    VehicleMakesComponent,
    PaggingComponent,
    VehicleMakeDetailComponent,
    VehicleMakeCreateComponent,
    VehicleModelsComponent,
    VehicleModelCreateComponent,
    VehicleModelDetailsComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

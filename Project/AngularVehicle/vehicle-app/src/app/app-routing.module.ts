import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VehiclemakesComponent } from './vehiclemakes/vehiclemakes.component';
import { VehiclemodelsComponent } from './vehiclemodels/vehiclemodels.component';

const routes: Routes = [
  {path: "vehiclemakes", component: VehiclemakesComponent},
  {path: "vehiclemodels", component: VehiclemodelsComponent}
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule { }

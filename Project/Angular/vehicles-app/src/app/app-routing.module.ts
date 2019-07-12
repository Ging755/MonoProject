import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { VehicleMakesComponent } from './Components/vehicle-makes/vehicle-makes.component';
import { VehicleMakeCreateComponent } from './Components/vehicle-makes/vehicle-make-create/vehicle-make-create.component';
import { VehicleModelsComponent } from './Components/vehicle-models/vehicle-models.component';
import { VehicleModelCreateComponent } from './Components/vehicle-models/vehicle-model-create/vehicle-model-create.component';
import { VehicleMakeDetailComponent } from './Components/vehicle-makes/vehicle-make-detail/vehicle-make-detail.component';
import { VehicleModelDetailsComponent } from './Components/vehicle-models/vehicle-model-details/vehicle-model-details.component';


const routes: Routes = [
  { path: "vehiclemakes", component : VehicleMakesComponent},
  { path: "vehiclemake/create", component : VehicleMakeCreateComponent},
  { path: "vehiclemodels", component : VehicleModelsComponent},
  { path: "vehiclemodel/create", component : VehicleModelCreateComponent},
  { path: "vehiclemake/details/:id", component : VehicleMakeDetailComponent},
  { path: "vehiclemodel/details/:id", component : VehicleModelDetailsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

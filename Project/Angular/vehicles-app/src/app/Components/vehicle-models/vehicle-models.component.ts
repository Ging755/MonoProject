import { Component, OnInit } from '@angular/core';
import { PagedVehicle } from 'src/app/Models/paged-vehicle';
import { VehicleModel } from 'src/app/Models/vehicle-model';
import { SortingParameters } from 'src/app/Models/parameters';
import { VehicleModelService } from 'src/app/Servies/vehicle-model.service';
import { VehicleMake } from 'src/app/Models/vehicle-make';
import { VehicleMakeService } from 'src/app/Servies/vehicle-make.service';

@Component({
  selector: 'app-vehicle-models',
  templateUrl: './vehicle-models.component.html',
  styleUrls: ['./vehicle-models.component.css']
})
export class VehicleModelsComponent implements OnInit {

  constructor(private vehiclemodelService : VehicleModelService, private vehiclemakeService : VehicleMakeService) { }

  vehiclemodels : PagedVehicle<VehicleModel>;
  makes : PagedVehicle<VehicleMake>;
  selectedmodel : VehicleModel;
  parameters : SortingParameters;
  makeId : number;
  page : number;
  details : boolean;
  ngOnInit() {
    this.parameters = {
      Search : "",
      OrderBy : "",
      OrderByDirection : ""
    }
    this.page = 1;
    this.getVehicleModels();
    this.getVehicleMakes();
  }

  onSelect(model : VehicleModel){
    this.selectedmodel = model;
    this.details = false;
  }

  getVehicleModels(){
    this.vehiclemodelService.getVehicleModels(this.page, 5, this.parameters, this.makeId).subscribe(x => this.vehiclemodels = x);
    this.details = true;
  }

  getVehicleMakes(){
    this.vehiclemakeService.getVehicleMakesSimple().subscribe(x => this.makes = x);
  }

  onPageChangedHandler(page : number){
    this.page = page;
    this.getVehicleModels();
  }
}

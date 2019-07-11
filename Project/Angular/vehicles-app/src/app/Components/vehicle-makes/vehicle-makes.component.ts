import { Component, OnInit } from '@angular/core';
import { VehicleMakeService } from 'src/app/Servies/vehicle-make.service';
import { PagedVehicle } from 'src/app/Models/paged-vehicle';
import { VehicleMake } from 'src/app/Models/vehicle-make';
import { SortingParameters } from 'src/app/Models/parameters';

@Component({
  selector: 'app-vehicle-makes',
  templateUrl: './vehicle-makes.component.html',
  styleUrls: ['./vehicle-makes.component.css']
})
export class VehicleMakesComponent implements OnInit {

  constructor(private vehiclemakeService : VehicleMakeService) { }

  vehiclemakes : PagedVehicle<VehicleMake>;
  selectedmake : VehicleMake;
  parameters : SortingParameters;
  page : number;
  details : boolean;
  ngOnInit() {
    this.parameters = {
      Search : "",
      OrderBy : "",
      OrderByDirection : ""
    }
    this.page = 1;
    this.getVehicleMakes();
  }
  onSelect(make : VehicleMake): void{
    this.selectedmake = make;
    this.details = false;
  }

  getVehicleMakes(){
      this.vehiclemakeService.getVehicleMakes(this.page , 5, this.parameters).subscribe(x => this.vehiclemakes = x);
      this.details = true;
  }

  onPageChangedHandler(page : number){
    this.page = page;
    this.getVehicleMakes();
  }
}

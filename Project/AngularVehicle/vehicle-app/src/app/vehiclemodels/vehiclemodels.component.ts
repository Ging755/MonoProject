import { Component, OnInit } from '@angular/core';
import { VehicleModelService } from '../vehiclemodel.service';
import { VehicleModel } from '../vehiclemodel';
import { PagedVehicleModel } from '../pagedvehiclemodel';
import { VehicleMakeService } from '../vehiclemake.service';
import { VehicleMake } from '../vehiclemake';
import { PagedVehicleMake } from '../pagedvehiclemake';
import {Pagging} from "../pagging.component"

@Component({
  selector: 'app-vehiclemodels',
  templateUrl: './vehiclemodels.component.html',
  styleUrls: ['./vehiclemodels.component.css']
})
export class VehiclemodelsComponent implements OnInit {

  constructor(private pagging : Pagging, private vehiclemodelService : VehicleModelService, private vehiclemakeService : VehicleMakeService) { }
  test : string;
  page : number;
  search : string;
  orderby : string;
  orderbydirection : string;
  filterbymake : number;
  vehiclemodel : VehicleModel = {
    Id : 0,
    Name : "",
    Abrv : "",
    MakeId : 0
  }
  pagedvehiclemake : PagedVehicleMake;
  selectedVehicleModel : VehicleModel;
  pagedvehiclemodel :PagedVehicleModel;
  ngOnInit() {
    this.page = 1;
    this.search = "";
    this.orderby = "";
    this.orderbydirection ="";
    this.filterbymake = null;
    this.getVehicleMakes();
    this.getVehicleModels();
  }

  onSelect(Id : number): void{
    this.vehiclemodelService.getVehicleModel(Id).subscribe(x => this.selectedVehicleModel = x);
  }

  filterVehicleModels() : void {
    this.page = 1;
    this.getVehicleModels();
  }

  getVehicleMakes(): void {
    this.vehiclemakeService.getVehicleMakes(0, 0, "", "", "").subscribe(pagedvehiclemake => this.pagedvehiclemake = pagedvehiclemake);
  }

  getVehicleModels(): void {
    this.vehiclemodelService.getVehicleModels(this.page, this.search, this.orderby, this.orderbydirection, this.filterbymake).subscribe(pagedvehiclemodel => this.pagedvehiclemodel = pagedvehiclemodel);
  }

  addVehicleModel(): void {
    if(!this.vehiclemodel.Name || !this.vehiclemodel.Abrv || !this.vehiclemodel.MakeId){
      return;
    }
    this.vehiclemodelService.addVehicleModel(this.vehiclemodel).subscribe(vehiclemodel => {
      this.getVehicleModels();
    });
  }

  deleteVehicleModel(model : VehicleModel): void{
    this.vehiclemodelService.deleteVehicleModel(model).subscribe(model => {
      this.getVehicleModels();
      this.onSelect(model.Id);
    });
  }
  previousPage(): void {
    this.page = this.pagging.previousPage(this.page, this.pagedvehiclemodel.TotalNumberOfPages)
    this.getVehicleModels();
  }
  nextPage(): void{
    this.page = this.pagging.nextPage(this.page, this.pagedvehiclemodel.TotalNumberOfPages)
    this.getVehicleModels();
  }
}

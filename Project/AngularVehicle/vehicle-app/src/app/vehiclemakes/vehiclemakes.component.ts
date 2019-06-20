import { Component, OnInit, ɵCodegenComponentFactoryResolver } from '@angular/core';
import { PagedVehicleMake } from '../pagedvehiclemake';
import { VehicleMake } from '../vehiclemake';
import { VehicleMakeService } from '../vehiclemake.service';
import {Pagging} from "../pagging.component"

@Component({
  selector: 'app-vehiclemakes',
  templateUrl: './vehiclemakes.component.html',
  styleUrls: ['./vehiclemakes.component.css']
})
export class VehiclemakesComponent implements OnInit {

  constructor(private vehiclemakeService : VehicleMakeService, private pagging : Pagging) { }
  page : number;
  pagesize : number;
  search : string;
  orderby : string;
  orderbydirection : string;
  vehiclemake : VehicleMake = {
    Id : 0,
    Name : "",
    Abrv : ""
  }
  selectedVehicleMake : VehicleMake;
  pagedvehiclemake :PagedVehicleMake;
  ngOnInit() {
    this.page = 1;
    this.pagesize = 5;
    this.search = "";
    this.orderby = "";
    this.orderbydirection ="";
    this.getVehicleMakes();
  }

  onSelect(vehiclemake : VehicleMake): void{
    this.selectedVehicleMake = vehiclemake;
  }

  filterVehicleMakes() : void {
    this.page = 1;
    this.getVehicleMakes();
  }

  getVehicleMakes(): void {
    this.vehiclemakeService.getVehicleMakes(this.page, this.pagesize, this.search, this.orderby, this.orderbydirection).subscribe(pagedvehiclemake => this.pagedvehiclemake = pagedvehiclemake);
  }

  addVehicleMake(): void {
    if(!this.vehiclemake.Name || !this.vehiclemake.Abrv){
      return;
    }
    this.vehiclemakeService.addVehicleMake(this.vehiclemake).subscribe(vehiclemake => {
      this.getVehicleMakes();
    });
  }

  deleteVehicleMake(make : VehicleMake): void{
    this.vehiclemakeService.deleteVehicleMake(make).subscribe(make => {
      this.getVehicleMakes();
      this.onSelect(make);
    });
  }
  previousPage(): void {
    this.page = this.pagging.previousPage(this.page, this.pagedvehiclemake.TotalNumberOfPages)
    this.getVehicleMakes();
  }
  nextPage(): void{
    this.page = this.pagging.nextPage(this.page, this.pagedvehiclemake.TotalNumberOfPages)
    this.getVehicleMakes();
  }
}

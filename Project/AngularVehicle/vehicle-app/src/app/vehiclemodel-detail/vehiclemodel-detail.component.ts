import { Component, OnInit, Input } from '@angular/core';
import { VehicleModel } from '../vehiclemodel';
import { VehicleModelService } from '../vehiclemodel.service';

@Component({
  selector: 'app-vehiclemodel-detail',
  templateUrl: './vehiclemodel-detail.component.html',
  styleUrls: ['./vehiclemodel-detail.component.css']
})
export class VehiclemodelDetailComponent implements OnInit {
  @Input() vehiclemodel : VehicleModel;
  constructor(private vehiclemodelservice : VehicleModelService) { }
  ngOnInit() {
    this.getVehicleModel();
  }
  getVehicleModel(){
    this.vehiclemodelservice.getVehicleModel(this.vehiclemodel.Id).subscribe(vehiclemodel => this.vehiclemodel = vehiclemodel);
  }
  Edit(vehiclemodel : VehicleModel) : void{
    if(!vehiclemodel.Name || !vehiclemodel.Abrv){
      return;
    }
    this.vehiclemodelservice.updateVehicleModel(vehiclemodel).subscribe()
  }
}

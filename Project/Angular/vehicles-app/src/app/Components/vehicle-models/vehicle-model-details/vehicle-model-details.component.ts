import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { VehicleModel } from 'src/app/Models/vehicle-model';
import { VehicleModelService } from 'src/app/Servies/vehicle-model.service';
import { VehicleMakeService } from 'src/app/Servies/vehicle-make.service';
import { VehicleMake } from 'src/app/Models/vehicle-make';

@Component({
  selector: 'app-vehicle-model-details',
  templateUrl: './vehicle-model-details.component.html',
  styleUrls: ['./vehicle-model-details.component.css']
})
export class VehicleModelDetailsComponent implements OnInit {

  @Input() model: VehicleModel

  @Output() modelChanged: EventEmitter<null> = new EventEmitter();

  make : VehicleMake;
  editedmodel : VehicleModel={
    Id : 0,
    Name : "",
    Abrv : "",
    MakeId : 0
  }

  constructor(private vehiclemodelService : VehicleModelService, private vehiclemakeService : VehicleMakeService) { 
  }

  ngOnInit() {
    this.vehiclemakeService.getVehicleMakeById(this.model.MakeId).subscribe(x => this.make = x);
  }

  onEdit(){
    this.editedmodel.Id = this.model.Id;
    this.editedmodel.MakeId = this.model.MakeId;
    if(this.editedmodel.Name == "" || this.editedmodel.Abrv == ""){
    }else{
    this.vehiclemodelService.editVehicleModel(this.editedmodel).subscribe(x => this.modelChanged.emit());
    }
  }
  onDelete(){
    this.vehiclemodelService.deleteVehicleModel(this.model.Id).subscribe(x => this.modelChanged.emit());
  }
}

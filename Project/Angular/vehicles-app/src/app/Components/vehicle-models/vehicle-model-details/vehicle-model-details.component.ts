import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { VehicleModel } from 'src/app/Models/vehicle-model';
import { VehicleModelService } from 'src/app/Servies/vehicle-model.service';
import { VehicleMakeService } from 'src/app/Servies/vehicle-make.service';
import { VehicleMake } from 'src/app/Models/vehicle-make';
import { Router, ActivatedRoute } from '@angular/router';
import { flatten } from '@angular/compiler';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-vehicle-model-details',
  templateUrl: './vehicle-model-details.component.html',
  styleUrls: ['./vehicle-model-details.component.css']
})
export class VehicleModelDetailsComponent implements OnInit {

  model: VehicleModel;
  make : VehicleMake;
  editForm : FormGroup;

  constructor(private fb : FormBuilder, private vehiclemodelService : VehicleModelService, private vehiclemakeService : VehicleMakeService, private router : Router, private route : ActivatedRoute) { 
  }

  ngOnInit() {
    this.vehiclemodelService.getVehicleModelById(+this.route.snapshot.paramMap.get("id")).subscribe(x => {
      this.model = x;
      this.editForm = this.fb.group({
        name : this.model.Name,
        abrv : this.model.Abrv
      })
      this.vehiclemakeService.getVehicleMakeById(this.model.MakeId).subscribe(x => {
        this.make = x;
      });
    });
  }

  onSubmit(data){
    this.model.Name = data.name;
    this.model.Abrv = data.abrv;
    this.vehiclemodelService.editVehicleModel(this.model).subscribe(x => this.router.navigate(["vehiclemodels"]));
  }

  onDelete(){
    this.vehiclemodelService.deleteVehicleModel(this.model.Id).subscribe(x => this.router.navigate(["vehiclemodels"]));
  }
}

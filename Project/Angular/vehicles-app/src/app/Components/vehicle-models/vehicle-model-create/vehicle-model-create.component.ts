import { Component, OnInit } from '@angular/core';
import { VehicleModel } from 'src/app/Models/vehicle-model';
import { VehicleModelService } from 'src/app/Servies/vehicle-model.service';
import { VehicleMakeService } from 'src/app/Servies/vehicle-make.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PagedVehicle } from 'src/app/Models/paged-vehicle';
import { VehicleMake } from 'src/app/Models/vehicle-make';
import { Router } from '@angular/router';

@Component({
  selector: 'app-vehicle-model-create',
  templateUrl: './vehicle-model-create.component.html',
  styleUrls: ['./vehicle-model-create.component.css']
})
export class VehicleModelCreateComponent implements OnInit {

  model : VehicleModel ={
    Id : 0,
    MakeId : 0,
    Name : "",
    Abrv : ""
  }

  makes : PagedVehicle<VehicleMake>;

  createForm : FormGroup;

  constructor(private vehiclemodelService : VehicleModelService, private vehiclemakeService : VehicleMakeService, private fb : FormBuilder, private router : Router) { 
    this.createForm = this.fb.group({
      name : "",
      abrv : "",
      makeId : ""
    })
  }

  ngOnInit() {
    this.vehiclemakeService.getVehicleMakesSimple().subscribe(x => this.makes = x);
  }

  onSubmit(modelData){
    this.model.Name = modelData.name;
    this.model.Abrv = modelData.abrv;
    this.model.MakeId = +modelData.makeId;
    this.vehiclemodelService.createVehicleModel(this.model).subscribe(x => this.router.navigate(["/vehiclemodels"]));
  }
}

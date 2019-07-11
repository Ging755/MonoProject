import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from "@angular/forms"
import { VehicleMakeService } from 'src/app/Servies/vehicle-make.service';
import { VehicleMake } from 'src/app/Models/vehicle-make';
import { Router } from '@angular/router';

@Component({
  selector: 'app-vehicle-make-create',
  templateUrl: './vehicle-make-create.component.html',
  styleUrls: ['./vehicle-make-create.component.css']
})
export class VehicleMakeCreateComponent implements OnInit {

  make : VehicleMake={
    Id: 0,
    Name : "",
    Abrv : ""
  }
  createForm : FormGroup;

  constructor(private vehiclemakeService : VehicleMakeService, private fb : FormBuilder, private router : Router) { 
    this.createForm = this.fb.group({
      name : "",
      abrv : ""
    })
  }

  ngOnInit() {
  }

  onSubmit(makeData){
    this.make.Name = makeData.name;
    this.make.Abrv = makeData.abrv;
    this.vehiclemakeService.createVehicleMake(this.make).subscribe(x => this.router.navigate(["/vehiclemakes"]));
    this.createForm.reset();
  }

}

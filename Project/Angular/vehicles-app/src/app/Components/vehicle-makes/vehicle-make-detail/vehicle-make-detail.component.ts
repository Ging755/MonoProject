import { Component, OnInit, Input, Output, EventEmitter} from '@angular/core';
import { VehicleMake } from 'src/app/Models/vehicle-make';
import { VehicleMakeService } from 'src/app/Servies/vehicle-make.service';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder } from '@angular/forms';


@Component({
  selector: 'app-vehicle-make-detail',
  templateUrl: './vehicle-make-detail.component.html',
  styleUrls: ['./vehicle-make-detail.component.css']
})
export class VehicleMakeDetailComponent implements OnInit {

  make : VehicleMake;
  editForm : FormGroup;

  constructor(private fb : FormBuilder, private vehiclemakeService : VehicleMakeService, private router : Router, private route : ActivatedRoute) {
   }

  ngOnInit() {
    this.vehiclemakeService.getVehicleMakeById(+this.route.snapshot.paramMap.get("id")).subscribe(x => {
      this.make = x;
      this.editForm = this.fb.group({
        name : this.make.Name,
        abrv : this.make.Abrv       
      })
    });
  }

  onSubmit(data){
    this.make.Name = data.name;
    this.make.Abrv = data.abrv;
    this.vehiclemakeService.editVehicleMake(this.make).subscribe(x => this.router.navigate(["vehiclemakes"]));
  }

  onDelete(){
    this.vehiclemakeService.deleteVehicleMake(this.make.Id).subscribe(x => this.router.navigate(["vehiclemakes"]));
  }
}

import { Component, OnInit, Input, Output, EventEmitter} from '@angular/core';
import { VehicleMake } from 'src/app/Models/vehicle-make';
import { VehicleMakeService } from 'src/app/Servies/vehicle-make.service';


@Component({
  selector: 'app-vehicle-make-detail',
  templateUrl: './vehicle-make-detail.component.html',
  styleUrls: ['./vehicle-make-detail.component.css']
})
export class VehicleMakeDetailComponent implements OnInit {

  @Input() make : VehicleMake;

  @Output() makeChanged: EventEmitter<null> = new EventEmitter();

  editedmake : VehicleMake = {
    Id : 0,
    Name : "",
    Abrv : ""
  }
  constructor(private vehiclemakeService : VehicleMakeService) {
   }

  ngOnInit() {
  }

  onEdit(){
    this.editedmake.Id = this.make.Id
    if(this.editedmake.Name == "" || this.editedmake.Abrv == ""){
    }else{
    this.vehiclemakeService.editVehicleMake(this.editedmake).subscribe(x => this.makeChanged.emit());
    }
  }

  onDelete(){
    this.vehiclemakeService.deleteVehicleMake(this.make.Id).subscribe(x => this.makeChanged.emit());
  }
}

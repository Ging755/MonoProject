import { Component, OnInit, Input} from '@angular/core';
import { VehicleMake } from '../vehiclemake';
import { VehicleMakeService } from '../vehiclemake.service';

@Component({
  selector: 'app-vehiclemake-detail',
  templateUrl: './vehiclemake-detail.component.html',
  styleUrls: ['./vehiclemake-detail.component.css']
})
export class VehiclemakeDetailComponent implements OnInit {
  @Input() vehiclemake : VehicleMake;
  constructor(private vehiclemakeservice : VehicleMakeService) { }
  ngOnInit() {
  }
  Edit(vehiclemake : VehicleMake) : void{
    if(!vehiclemake.Name || !vehiclemake.Abrv){
      return;
    }
    this.vehiclemakeservice.updateVehicleMake(vehiclemake).subscribe()
  }
}

import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { PagedVehicle } from '../Models/paged-vehicle';
import { VehicleMake } from '../Models/vehicle-make';
import { SortingParameters } from '../Models/parameters';
import {WebAPIUrls} from "./web-apiurls"
import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class VehicleMakeService {

  constructor(private http: HttpClient) { }


  getVehicleMakes(page : number, pagesize : number, parameters : SortingParameters): Observable<PagedVehicle<VehicleMake>>{
    return this.http.get<PagedVehicle<VehicleMake>>(WebAPIUrls.VehicleMakeUrl + "/?page=" + page + "&pagesize=" + pagesize + "&search=" + parameters.Search + "&sort=" + parameters.OrderBy + "&direction=" + parameters.OrderByDirection);
  }

  getVehicleMakeById(id : Number): Observable<VehicleMake>{
    return this.http.get<VehicleMake>(WebAPIUrls.VehicleMakeUrl + "/" + id);
  }

  getVehicleMakesSimple(): Observable<PagedVehicle<VehicleMake>>{
    return this.http.get<PagedVehicle<VehicleMake>>(WebAPIUrls.VehicleMakeUrl + "/?page=" + "&pagesize=" + "&search=" + "&sort=" + "&direction=");
  }

  createVehicleMake(make : VehicleMake) : Observable<any>{
    return this.http.post<VehicleMake>(WebAPIUrls.VehicleMakeUrl, make, httpOptions);
  }
  editVehicleMake(make : VehicleMake) : Observable<any>{
    return this.http.put<VehicleMake>(WebAPIUrls.VehicleMakeUrl + "/" + make.Id, make, httpOptions);
  }

  deleteVehicleMake(id : Number) : Observable<any>{
    return this.http.delete(WebAPIUrls.VehicleMakeUrl + "/" + id);
  }
}

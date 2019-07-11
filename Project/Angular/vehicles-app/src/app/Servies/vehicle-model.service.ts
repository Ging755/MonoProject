import { Injectable } from '@angular/core';
import { SortingParameters } from '../Models/parameters';
import { Observable, of } from 'rxjs';
import { PagedVehicle } from '../Models/paged-vehicle';
import { VehicleModel } from '../Models/vehicle-model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { WebAPIUrls } from './web-apiurls';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class VehicleModelService {

  constructor(private http : HttpClient) { }

    /**GET vehicle makes from API */
    getVehicleModels(page : number, pagesize : number, parameters : SortingParameters, makeId : number): Observable<PagedVehicle<VehicleModel>>{
      return this.http.get<PagedVehicle<VehicleModel>>(WebAPIUrls.VehicleModelUrl + "/?page=" + page + "&pagesize=" + pagesize + "&search=" + parameters.Search + "&sort=" + parameters.OrderBy + "&direction=" + parameters.OrderByDirection + "&makeid=" + makeId)
    }
  
    createVehicleModel(model : VehicleModel) : Observable<any>{
      return this.http.post<VehicleModel>(WebAPIUrls.VehicleModelUrl, model, httpOptions)
    }
    editVehicleModel(model : VehicleModel) : Observable<any>{
      return this.http.put<VehicleModel>(WebAPIUrls.VehicleModelUrl + "/" + model.Id, model, httpOptions);
    }
  
    deleteVehicleModel(id : Number) : Observable<any>{
      return this.http.delete(WebAPIUrls.VehicleModelUrl + "/" + id);
    }
}

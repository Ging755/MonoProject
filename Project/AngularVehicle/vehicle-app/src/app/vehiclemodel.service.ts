import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { MessageService } from './message.service';

import { PagedVehicleModel } from './pagedvehiclemodel';
import { Observable, of } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { VehicleModel } from './vehiclemodel';
import {WebAPIURLs} from "./WebAPIUrls"

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class VehicleModelService {

  constructor(private http: HttpClient, private messageService: MessageService) { }
      /**GET vehiclemodels from the server */
      getVehicleModel(Id : number) : Observable<VehicleModel>{
        return this.http.get<VehicleModel>(WebAPIURLs.VehicleModelUrl + "/" + Id)
        .pipe(
          tap(_ => this.log('fetched vehiclemodel')),
          catchError(this.handleError<VehicleModel>('getVehicleModel', ))
        );
      }
    /**GET vehiclemodels from the server */
    getVehicleModels(page : number, search : string, sort : string, direction : string, makeid : number) : Observable<PagedVehicleModel>{
      return this.http.get<PagedVehicleModel>(WebAPIURLs.VehicleModelUrl + "/?page=" + page + "&pagesize="+ "&search=" + search + "&sort=" + sort + "&direction=" + direction + "&makeid=" + makeid)
      .pipe(
        tap(_ => this.log('fetched vehiclemodels')),
        catchError(this.handleError<PagedVehicleModel>('getVehicleModels', ))
      );
    }
      /** POST: add a new vehiclemodel to the server */
  addVehicleModel(vehiclemodel : VehicleModel) : Observable<VehicleModel>{
    return this.http.post<VehicleModel>(WebAPIURLs.VehicleModelUrl, vehiclemodel, httpOptions).pipe(
      tap((newVehicleModel : VehicleModel) => this.log("added vehicle model w/ id=${newVehicleModel.Id}")),
      catchError(this.handleError<VehicleModel>("addVehicleModel", ))
    );
  }

  /** PUT: update the vehiclemodel on the server */
  updateVehicleModel(vehiclemodel : VehicleModel) : Observable<any>{
    return this.http.put(WebAPIURLs.VehicleModelUrl + "/" + vehiclemodel.Id, vehiclemodel, httpOptions).pipe(
      tap(_ => this.log("updated vehiclemodel id=${vehiclemodel.Id}")),
      catchError(this.handleError<any>('updateVehicleModel',))
    );
  }

    /** DELETE: delete the model from the server */
  deleteVehicleModel(vehiclemodel : VehicleModel): Observable<VehicleModel> {
    return this.http.delete<VehicleModel>(WebAPIURLs.VehicleModelUrl + "/" + vehiclemodel.Id, httpOptions).pipe(
      tap(_ => this.log("deleted vehiclemodel id=${vehiclemodel.Id}")),
      catchError(this.handleError<VehicleModel>('deletedVehicleModel'))
    );
  }
        /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
 
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
 
      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);
 
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
  private log(message: string) {
    this.messageService.add(`HeroService: ${message}`);
  }
}


import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators'

import {PagedVehicleMake} from "./pagedvehiclemake";
import { MessageService } from './message.service';
import { VehicleMake } from './vehiclemake';
import { WebAPIURLs} from "./WebAPIUrls";

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class VehicleMakeService {

  constructor(private http: HttpClient, private messageService : MessageService) { }
  /**GET vehiclemakes from the server */
  getVehicleMakes(page : number, pagesize:number, search : string, sort : string, direction : string) : Observable<PagedVehicleMake>{
    return this.http.get<PagedVehicleMake>(WebAPIURLs.VehicleMakeUrl + "/?page=" + page + "&pagesize="+ pagesize + "&search=" + search + "&sort=" + sort + "&direction=" + direction)
    .pipe(
      tap(_ => this.log('fetched vehiclemakes')),
      catchError(this.handleError<PagedVehicleMake>('getVehicleMakes', ))
    );
  }

  /** POST: add a new vehiclemake to the server */
  addVehicleMake(vehiclemake : VehicleMake) : Observable<VehicleMake>{
    return this.http.post<VehicleMake>(WebAPIURLs.VehicleMakeUrl, vehiclemake, httpOptions).pipe(
      tap((newVehicleMake : VehicleMake) => this.log("added vehicle make w/ id=${newVehicleMake.Id}")),
      catchError(this.handleError<VehicleMake>("addVehicleMake", ))
    );
  }

  /** PUT: update the vehiclemake on the server */
  updateVehicleMake(vehiclemake : VehicleMake) : Observable<any>{
    return this.http.put(WebAPIURLs.VehicleMakeUrl + "/" + vehiclemake.Id, vehiclemake, httpOptions).pipe(
      tap(_ => this.log("updated vehiclemake id=${vehiclemake.Id}")),
      catchError(this.handleError<any>('updateVehicleMake',))
    );
  }

    /** DELETE: delete the model from the server */
  deleteVehicleMake(vehiclemake : VehicleMake): Observable<VehicleMake> {
    return this.http.delete<VehicleMake>(WebAPIURLs.VehicleMakeUrl + "/" + vehiclemake.Id, httpOptions).pipe(
      tap(_ => this.log("deleted vehiclemake id=${vehiclemake.Id}")),
      catchError(this.handleError<VehicleMake>('deletedVehicleMake'))
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
    /** Log a VehicleMakeService message with the MessageService */
    private log(message: string) {
      this.messageService.add(`VehicleMakeService: ${message}`);
    }
}

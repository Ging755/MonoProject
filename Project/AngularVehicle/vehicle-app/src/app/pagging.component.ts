import { Injectable } from '@angular/core';
@Injectable({
    providedIn: 'root',
})
export class Pagging{
    constructor() {}
    previousPage(page : number, TotalNumberOfPages: number): void {
        page = page - 1;
        if(page == 0){
          page = TotalNumberOfPages;
        }
      }
      nextPage(page : number, TotalNumberOfPages: number): void{
        page = page + 1;
        if(page > TotalNumberOfPages){
          page = 1;
        }
      }
}
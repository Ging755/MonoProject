import { Injectable } from '@angular/core';
@Injectable({
    providedIn: 'root',
})
export class Pagging{
    constructor() {}
    previousPage(page : number, TotalNumberOfPages: number): number {
        page = page - 1;
        if(page == 0){
          page = TotalNumberOfPages;
        }
        return page;
      }
      nextPage(page : number, TotalNumberOfPages: number): number{
        page = page + 1;
        if(page > TotalNumberOfPages){
          page = 1;
        }
        return page;
      }
}
import { VehicleMake } from './vehiclemake';

export class PagedVehicleMake{
    Results : VehicleMake[];
    TotalNumberOfPages : number;
    PageSize : number;
    PageNumber : number;
}
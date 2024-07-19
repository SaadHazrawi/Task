import { Injectable } from '@angular/core';
import { CustomService } from './custom.service';
import { environment } from '../environments/environment';
import { Observable } from 'rxjs';
import { IPaginationResponse } from '../model/response';
import { ICategory } from '../model/category';

@Injectable({
  providedIn: 'root'
})
export class CategoreyService {

  constructor(private customeServices: CustomService) { }
  private url: string = environment.apiUrl;
  getCategories(pageIndex: number = 0, pageSize: number = 50): Observable<IPaginationResponse<ICategory>> {
    const apiUrl = `${this.url}Categories?pageIndex=${pageIndex}&pageSize=${pageSize}`;
    return this.customeServices.getRequests<IPaginationResponse<ICategory>>(apiUrl);
  }
}

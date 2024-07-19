import { Injectable } from '@angular/core';
import { CustomService } from './custom.service';
import { environment } from '../environments/environment';
import { ISubCategorey } from '../model/subCategorey';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SubCategoreyService {
  private url: string = environment.apiUrl;

  constructor(private customService: CustomService) { }

  getSubCategories(categoryId: number): Observable<ISubCategorey[]> {
    const apiUrl = `${this.url}SubCategories/${categoryId}`;
    
    return this.customService.getRequests<ISubCategorey[]>(apiUrl);
  }
}

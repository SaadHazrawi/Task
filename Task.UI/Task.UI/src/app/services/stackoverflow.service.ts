import { Injectable } from '@angular/core';
import { CustomService } from './custom.service';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';
import { IStackOverFlowPost } from '../model/stackoverflow';

@Injectable({
  providedIn: 'root'
})
export class StackoverflowService {
  constructor(private customeServices: CustomService) { }
  url: string = environment.apiUrl;
  getStackPosts(pageSize: number = 50): Observable<IStackOverFlowPost[]> {
    return this.customeServices.getRequests<IStackOverFlowPost[]>(this.url + `StackOverflow/latestQuestions?pageSize=${pageSize}`);
  }

}


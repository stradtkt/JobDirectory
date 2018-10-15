import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class JobService {
  myAppUrl = '';
  constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
  }
  getUserList() {
    return this.http.get(this.myAppUrl + 'api/Job/GetUserList')
      .map((response: Response) => response.json())
      .catch(this.errorHandler);
  }
  getJobs() {
    return this.http.get(this.myAppUrl + 'api/Job/Index')
      .map((response: Response) => response.json())
      .catch(this.errorHandler);
  }
    getJobById(id: number) {
      return this.http.get(this.myAppUrl + 'api/Job/Details/' + id)
        .map((response: Response) => response.json())
        .catch(this.errorHandler);
    }
    saveJob(job) {
      return this.http.post(this.myAppUrl + 'api/Job/Create', job)
        .map((response: Response) => response.json())
        .catch(this.errorHandler);
    }
    updateJob(job) {
      return this.http.put(this.myAppUrl + 'api/Job/Edit', job)
        .map((response: Response) => response.json())
        .catch(this.errorHandler);
    }
    deleteJob(id) {
      return this.http.delete(this.myAppUrl + 'api/Job/Delete/' + id)
        .map((response: Response) => response.json())
        .catch(this.errorHandler);
    }
  errorHandler(error: Response) {
    console.log(error);
    return Observable.throw(error);
  }
}

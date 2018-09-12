import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { Value } from '../_models/value';

const httpOptions = {
  headers: new HttpHeaders({
    'Authorization': 'Bearer ' + localStorage.getItem('token')
  })
};

@Injectable({
  providedIn: 'root'
})
export class ValueService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getValues(): Observable<Value[]> {
    return this.http.get<Value[]>(this.baseUrl + 'values/');
  }

  getValue(id): Observable<Value> {
    return this.http.get<Value>(this.baseUrl + 'values/' + id);
  }

}

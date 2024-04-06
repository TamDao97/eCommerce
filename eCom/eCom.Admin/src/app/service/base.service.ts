import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class BaseService {
  url: string = '';
  constructor(private _httpClient: HttpClient) {}

  create(payload: any): Observable<any> {
    return this._httpClient.post(this.url, payload);
  }

  update(payload: any): Observable<any> {
    return this._httpClient.post(this.url, payload);
  }

  delete(id: any): Observable<any> {
    return this._httpClient.post(this.url, null);
  }

  getById(id: any): Observable<any> {
    return this._httpClient.get(this.url);
  }

  getByFilter(payload: any): Observable<any> {
    return this._httpClient.post(this.url, payload);
  }
}

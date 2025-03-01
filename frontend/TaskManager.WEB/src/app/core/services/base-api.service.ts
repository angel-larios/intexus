import { HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
  })
  export class BaseApiService {
  
    constructor(protected http: HttpClient) { }
  
    get<T>(url: string): Observable<T> {
      return this.http.get<T>(url);
    }
    
    post<T>(url: string, body: any): Observable<T> {
      return this.http.post<T>(url, body);
    }

    delete<T>(url: string): Observable<T> {
      return this.http.delete<T>(url);
    }
    patch<T>(url: string, body: any): Observable<T> {
        return this.http.patch<T>(url, body);
    }
  }

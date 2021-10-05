import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root",
})
export class ApiService {
  constructor(protected http: HttpClient) {}

  get<T>(path: string, params: HttpParams = new HttpParams()): Observable<T> {
    return this.http.get<T>(`${environment.api_url}${path}`, { params });
  }

  post(path: string, body: Object = {}, options?: any): Observable<any> {
    return this.http.post(`${environment.api_url}${path}`, body, options);
  }

  postwithData<T>(path: string, body: Object = {}, options?: any): Observable<any> {
    return this.http.post<T>(`${environment.api_url}${path}`, body, options);
  }

  postwithDataBlod<T>(path: string, body: FormData, options?: any): Observable<any> {
    return this.http.post<T>(`${environment.api_url}${path}`, body, options);
  }

}

import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

import { Weather } from '../models/weather.model';

@Injectable({
  providedIn: 'root'
})
export class WeatherService {

  constructor(private http: HttpClient) { }

  getCurrentWeather(): Observable<any> {
    return this.http.get<any>('https://api.openweathermap.org/data/2.5/weather?' +
      'lat=33.6&lon=-111.89&APPID=952d6b1a52fe15a7b901720074680562')
      .pipe(map((res: Response) => {
        return {
          cityName: res.json()
        };
      }));
  }
}

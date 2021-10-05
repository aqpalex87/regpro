import {Injectable} from '@angular/core';

@Injectable()
export class Weather {
    cityName: string;
    temp: number;
    minTemp: number;
    maxTemp: number;
    lat: number;
    lon: number;
}

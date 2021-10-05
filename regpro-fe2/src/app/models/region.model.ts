import {Injectable} from '@angular/core';

@Injectable()
export class RegionModel{
    idRegion: string;
    name: string;
    pointX?: string;
    pointY?: string;
    zoom?: number
}

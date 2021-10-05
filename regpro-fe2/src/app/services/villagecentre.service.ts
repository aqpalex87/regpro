import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { VillageCentre } from '../models/villagecentre.model';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class VillagecentreService {

  constructor(private apiService: ApiService) { }

  getVillageCentre(ubigeo: string, codUgel: string): Observable<VillageCentre[]> {
    return this.apiService.get<VillageCentre[]>(`/CentroPoblado/GetAllCentrosPoblado/${ubigeo}/${codUgel}`);
  }
}

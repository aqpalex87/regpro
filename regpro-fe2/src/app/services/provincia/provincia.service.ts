import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ApiService } from "src/app/services/api.service";

@Injectable({ providedIn: "root" })
export class ProvinciaService {
  constructor(private readonly apiService: ApiService) {}

  getProvinciaByIdRegionData(codGroup: string,idRegion: string): Observable<any> {
    return this.apiService.get(`/Provincia/GetProvinciaByCodUgel/${codGroup}/${idRegion}`);
  }
}

import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ApiService } from "src/app/services/api.service";

@Injectable({ providedIn: "root" })
export class RegionService {
  constructor(private readonly apiService: ApiService) {}

  getRegionData(codUgel: string): Observable<any> {
    return this.apiService.get(`/Region/GetAllRegionByCodUgel/${codUgel}`);
  }

}

import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ApiService } from "src/app/services/api.service";

@Injectable({ providedIn: "root" })
export class RegProProgramaService {
  constructor(private readonly apiService: ApiService) {}

  getProgramaByCodigoModular(codModular: string, codoii: string): Observable<any> {
    return this.apiService.get(`/TblRegproPrograma/GetProgramaByCodigoModular/${codModular}/${codoii}`);
  }

  getCenterEducationalNear(codModular: string, codUgel: string): Observable<any> {
    return this.apiService.get(`/TblRegproPrograma/GetCenterEducationalNear/${codModular}/${codUgel}`);
  }

}

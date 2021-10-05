import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ApiService } from "src/app/services/api.service";

@Injectable({ providedIn: "root" })
export class DistritoService {
  constructor(private readonly apiService: ApiService) {}

  getDistritoByIdProvinciaData(codUgel: string,idProvincia: string): Observable<any> {
    return this.apiService.get(`/Distrito/GetDistritoByIdProvincia/${codUgel}/${idProvincia}`);
  }



}

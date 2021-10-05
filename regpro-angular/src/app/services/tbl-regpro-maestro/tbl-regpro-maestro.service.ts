import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ApiService } from "src/app/services/api.service";

@Injectable({ providedIn: "root" })
export class RegProMaestroService {
  constructor(private readonly apiService: ApiService) {}

  getAllByCodGrop(codGroup: string): Observable<any> {
    return this.apiService.get(`/TblRegproMaestro/GetAllByCodGrop/${codGroup}`);
  }

  getAllByCodGropAndIdMaestropadre(codGroup: string, idMaestropadre: number): Observable<any> {
    return this.apiService.get(`/TblRegproMaestro/GetAllByCodGropAndIdMaestropadre/${codGroup}/${idMaestropadre}`);
  }  

}

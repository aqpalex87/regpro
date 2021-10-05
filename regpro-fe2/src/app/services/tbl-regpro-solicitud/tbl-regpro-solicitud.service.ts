import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { TblregprosolicitudModel } from "../../models/tblregprosolicitud/tblregprosolicitud.model";
import { ApiService } from "../api.service";
import { RequestModel } from "../../models/request.model";

@Injectable({ providedIn: "root" })
export class TblRegproSolicitudService {
  constructor(private readonly apiService: ApiService) {}

  getIdentificationData(nIdSolicitud: number): Observable<TblregprosolicitudModel> {
    return this.apiService.get(`/TblRegproSolicitud/GetFindRequest/${nIdSolicitud}`);
  }

  saveRequest(requestToInsert: FormData) : Observable<RequestModel> {
    return this.apiService.postwithDataBlod<RequestModel>("/TblRegproSolicitud", requestToInsert);
  }

//   postTblRegproSolicitud(datos: TblregprosolicitudModel): Observable<any> {
//     console.log('request2');
//     console.log(datos);
//     return this.apiService.postwithData(`/Solicitudes`,datos);
//   }

// postTblRegproSolicitud(requestToInsert: FormData) : Observable<any> {
//   return this.apiService.postwithData<TblregprosolicitudModel>("/Solicitudes", requestToInsert);
// }
 }

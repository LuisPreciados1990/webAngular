import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IDp01a110 } from '../../../models/Formas/CNT/dp01a110';

@Injectable({
  providedIn: 'root'
})
export class Dp01a110Service {
  private apiURL = this.baseUrl + "api/DP01A110";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getPlanCta(): Observable<IDp01a110[]> {
    return this.http.get<IDp01a110[]>(this.apiURL + "/GetPlan");
  }

  getPlanCtaByNombre(nombre:string): Observable<IDp01a110[]> {
    return this.http.get<IDp01a110[]>(this.apiURL + "/getPlanCtaByNombre/" + nombre);
  }

  getPlanCtaByCodigo(codigo: string): Observable<IDp01a110> {
    return this.http.get<IDp01a110>(this.apiURL + "/getPlanCtaByCodigo/" + codigo);
  }

  getPlanCtaByNombreOrAux(param: string): Observable<IDp01a110[]> {
    return this.http.get<IDp01a110[]>(this.apiURL + "/getPlanCtaByNombreOrAux/" + param);
  }

  SaveCta(cta: IDp01a110): Observable<IDp01a110> {
    return this.http.post<IDp01a110>(this.apiURL + "/saveCta", cta);
  }

  UpdateCtaById(cta: IDp01a110): Observable<IDp01a110> {
    return this.http.put<IDp01a110>(this.apiURL + "/updateCtaById/"+cta.id, cta);
  }

  deleteCtaById(cta: IDp01a110): Observable<IDp01a110> {
    return this.http.delete<IDp01a110>(this.apiURL + "/deleteCtaById/" + cta.id);
  }
}

import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IDp01acco } from '../../../models/Formas/CNT/dp01acco';

@Injectable({
  providedIn: 'root'
})
export class Dp01accoService {

  private apiURL = this.baseUrl + "api/DP01ACCO";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getCCosto(): Observable<IDp01acco[]> {
    return this.http.get<IDp01acco[]>(this.apiURL + "/getCCosto");
  }

  getCCostoByNombre(nombre: string): Observable<IDp01acco[]> {
    return this.http.get<IDp01acco[]>(this.apiURL + "/getCCostoByNombre/" + nombre);
  }

  getCCostoByCodigo(codigo: string): Observable<IDp01acco> {
    return this.http.get<IDp01acco>(this.apiURL + "/getCCostoByCodigo/" + codigo);
  }

  saveCCosto(cco: IDp01acco): Observable<IDp01acco> {
    return this.http.post<IDp01acco>(this.apiURL + "/saveCCosto", cco);
  }

  updateCCostoById(cco: IDp01acco): Observable<IDp01acco> {
    return this.http.put<IDp01acco>(this.apiURL + "/updateCCostoById/" + cco.id, cco);
  }

  deleteCCostoById(cco: IDp01acco): Observable<IDp01acco> {
    return this.http.delete<IDp01acco>(this.apiURL + "/deleteCCostoById/" + cco.id);
  }

}

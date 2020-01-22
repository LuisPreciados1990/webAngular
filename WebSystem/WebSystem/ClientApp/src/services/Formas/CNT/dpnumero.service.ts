import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IDpnumero } from '../../../models/Formas/CNT/dpnumero';
import { ISp_Numsecu,ISecuancia } from '../../../models/StoredProcedure/sp_Numsecu';

@Injectable({
  providedIn: 'root'
})
export class DpnumeroService {
  private apiURL = this.baseUrl + "api/DPNUMERO";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getDPNumero(): Observable<IDpnumero[]> {
    return this.http.get<IDpnumero[]>(this.apiURL + "/getDPNumero");
  }

  getTrnCntByNombre(nombre: string): Observable<IDpnumero[]> {
    return this.http.get<IDpnumero[]>(this.apiURL + "/getTrnCntByNombre/" + nombre);
  }

  getTrnCntByCodigo(codigo: string): Observable<IDpnumero> {
    return this.http.get<IDpnumero>(this.apiURL + "/getTrnCntByCodigo/" + codigo);
  }

  saveDpnumero(vari: IDpnumero): Observable<IDpnumero> {
    return this.http.post<IDpnumero>(this.apiURL + "/saveDpnumero", vari);
  }

  updateDpnumero(vari: IDpnumero): Observable<IDpnumero> {
    return this.http.put<IDpnumero>(this.apiURL + "/updateDpnumero/" + vari.id, vari);
  }

  deleteDpnumeroById(vari: IDpnumero): Observable<IDpnumero> {
    return this.http.delete<IDpnumero>(this.apiURL + "/deleteDpnumeroById/" + vari.id);
  }

  secuanciaCnt(spNumsec: ISp_Numsecu): Observable<ISecuancia> {    
    return this.http.post<ISecuancia>(this.apiURL + "/secuenciaCnt",spNumsec);
  }
  
  getReten(): Observable<IDpnumero[]> {
    return this.http.get<IDpnumero[]>(this.apiURL + "/getRetenci");
  }

  getRetenciById(codigo: string): Observable<IDpnumero> {
    return this.http.get<IDpnumero>(this.apiURL + "/getRetenciById/" + codigo);
  }

}

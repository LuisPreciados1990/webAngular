import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IDp03acom } from '../../../models/Formas/INV/dp03acom';

@Injectable({
  providedIn: 'root'
})
export class Dp03acomService {

  private apiURL = this.baseUrl + "api/DP03ACOM";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  GetComprobaInvByGrupo(grupo: string): Observable<IDp03acom[]> {
    return this.http.get<IDp03acom[]>(this.apiURL + "/GetComprobaInvByGrupo/"+grupo);
  }

  GetComprobaInvByCod(codigo: string): Observable<IDp03acom> {
    return this.http.get<IDp03acom>(this.apiURL + "/GetComprobaInvByCod/" + codigo);
  }

  getTransacINv(codigo: string, grupo: string): Observable<IDp03acom> {
    return this.http.get<IDp03acom>(this.apiURL + "/getTransacINv/" + codigo + "/" + grupo);
  }
}

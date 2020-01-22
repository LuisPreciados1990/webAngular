import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { IDp02a110 } from '../../../models/Formas/BAN/dp02a110';

@Injectable({
  providedIn: 'root'
})
export class Dp02a110Service {
  private apiURL = this.baseUrl + "api/DP02A110";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getBancos(): Observable<IDp02a110[]> {
    return this.http.get<IDp02a110[]>(this.apiURL + "/getBancos");
  }

  getBcoIngreso(): Observable<any[]> {    
    return this.http.post<any[]>(this.apiURL + "/getBcoIngreso",null);
  }

  getBcoByNombre(nombre: string): Observable<IDp02a110[]> {
    return this.http.get<IDp02a110[]>(this.apiURL + "/getBcoByNombre/" + nombre);
  }

  getBcoByCodigo(codigo: string): Observable<IDp02a110> {
    return this.http.get<IDp02a110>(this.apiURL + "/getBancosByCodigo/" + codigo);
  }

  saveBco(bco: IDp02a110): Observable<IDp02a110> {
    return this.http.post<IDp02a110>(this.apiURL + "/saveBco", bco);
  }

  updateBcoById(bco: IDp02a110): Observable<IDp02a110> {
    return this.http.put<IDp02a110>(this.apiURL + "/updateBcoById/" + bco.id, bco);
  }

  deleteBcoById(bco: IDp02a110): Observable<IDp02a110> {
    return this.http.delete<IDp02a110>(this.apiURL + "/deleteBcoById/" + bco.id);
  }

}

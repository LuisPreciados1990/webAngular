import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IDp05a110 } from '../../../models/Formas/COB/dp05a110';

@Injectable({
  providedIn: 'root'
})
export class Dp05a110Service {
  private apiURL = this.baseUrl + "api/DP05A110";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  GetClienteByCodigo(codigo: string): Observable<IDp05a110> {
    return this.http.get<IDp05a110>(this.apiURL + "/GetClienteByCodigo/" + codigo);
  }

  GetClienteByNombre(nombre: string): Observable<IDp05a110[]> {
    return this.http.get<IDp05a110[]>(this.apiURL + "/GetClienteByNombre/" + nombre);
  }

  GetClientes(): Observable<IDp05a110[]> {
    return this.http.get<IDp05a110[]>(this.apiURL + "/GetClientes");
  }

}

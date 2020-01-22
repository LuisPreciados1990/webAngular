import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IDp06a110 } from '../../../models/Formas/PAG/dp06a110';

@Injectable({
  providedIn: 'root'
})
export class Dp06a110Service {
  private apiURL = this.baseUrl + "api/DP06A110";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getProveedorByCodigo(codigo: string): Observable<IDp06a110> {
    return this.http.get<IDp06a110>(this.apiURL + "/getProveedorByCodigo/" + codigo);
  }

  getProveedorByNombre(nombre: string): Observable<IDp06a110[]> {
    return this.http.get<IDp06a110[]>(this.apiURL + "/getProveedorByNombre/" + nombre);
  }

  getProveedores(): Observable<IDp06a110[]> {
    return this.http.get<IDp06a110[]>(this.apiURL + "/getProveedores");
  }

}

import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IDp01amov } from '../../../models/Formas/CNT/dp01amov';

@Injectable({
  providedIn: 'root'
})
export class Dp01amovService {
  private apiURL = this.baseUrl + "api/DP01AMOV";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  save01Amov(detalle: IDp01amov[]): Observable<IDp01amov[]> {    
    return this.http.post<IDp01amov[]>(this.apiURL + "/create01Amov", detalle);
  }

  getD01amov(tipo_asi: string, asiento: string): Observable<IDp01amov[]> {
    return this.http.get<IDp01amov[]>(this.apiURL + "/getD01amov/" + tipo_asi + "/" + asiento);
  }

  update01Amov(detalle: IDp01amov[]): Observable<IDp01amov[]> {    
    return this.http.put<IDp01amov[]>(this.apiURL + "/update01Amov", detalle);
  }
}

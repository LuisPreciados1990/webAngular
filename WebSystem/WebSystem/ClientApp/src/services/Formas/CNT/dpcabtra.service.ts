import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IDpcabtra } from '../../../models/Formas/CNT/dpcabtra';

@Injectable({
  providedIn: 'root'
})
export class DpcabtraService {
  private apiURL = this.baseUrl + "api/DPCABTRA";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  saveCabTra(cabeza: IDpcabtra): Observable<IDpcabtra> {
    return this.http.post<IDpcabtra>(this.apiURL + "/createCabTra", cabeza);
  }

  getDpcabtra(tipo_asi: string, asiento: string): Observable<IDpcabtra> {
    return this.http.get<IDpcabtra>(this.apiURL + "/getDpcabtra/" + tipo_asi + "/"+asiento);
  }

  updateCabTra(cabeza: IDpcabtra): Observable<IDpcabtra> {
    return this.http.put<IDpcabtra>(this.apiURL + "/updateCabTra/" + cabeza.id, cabeza);
  }
}

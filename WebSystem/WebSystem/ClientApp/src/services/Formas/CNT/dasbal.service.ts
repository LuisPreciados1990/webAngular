import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IDasbal } from '../../../models/Formas/CNT/dasbal';

@Injectable({
  providedIn: 'root'
})
export class DasbalService {
  private apiURL = this.baseUrl + "api/DASBAL";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getDasBal(): Observable<IDasbal> {
    return this.http.get<IDasbal>(this.apiURL + "/getDasBal");
  }

  updateDasBalId(das: IDasbal): Observable<IDasbal> {
    return this.http.put<IDasbal>(this.apiURL + "/updateDasBalId/" + das.id, das);
  }
}

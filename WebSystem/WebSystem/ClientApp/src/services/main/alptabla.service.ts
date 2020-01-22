import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IAlptabla } from '../../models/main/alptabla';


@Injectable({
  providedIn: 'root'
})
export class AlptablaService {
  private apiURL = this.baseUrl + "api/AlpTabla";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  GetAlpTabla(nomtag: string): Observable<IAlptabla[]> {
    return this.http.get<IAlptabla[]>(this.apiURL + "/GetAlpTabla/" + nomtag);
  }

  getAlpTablaCod(nomtag: string,codigo:string): Observable<IAlptabla> {
    return this.http.get<IAlptabla>(this.apiURL + "/getAlpTablaCod/" + nomtag+"/"+codigo);
  }

}

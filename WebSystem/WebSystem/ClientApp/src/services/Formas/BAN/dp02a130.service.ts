import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IDp02a130, IDp02a130EXT } from '../../../models/Formas/BAN/dp02a130';


@Injectable({
  providedIn: 'root'
})
export class Dp02a130Service {
  private apiURL = this.baseUrl + "api/DP02A130";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getReten(): Observable<IDp02a130[]> {
    return this.http.get<IDp02a130[]>(this.apiURL + "/getReten");
  }

  getRetTempo(): Observable<IDp02a130EXT[]> {
    return this.http.get<IDp02a130EXT[]>(this.apiURL + "/getRetTempo");
  }
}

import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HelpGenService {
  private apiURL = this.baseUrl + "api/Dbhelpgen";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getHelpGen(help: string): Observable<any[]> {
    return this.http.post<any[]>(this.apiURL + "/getHelpgen/" + help, null);
  }
}

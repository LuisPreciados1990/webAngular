import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IParamRepo } from '../../models/main/paramrepo';

@Injectable({
  providedIn: 'root'
})
export class RepomanService {
  private apiURL = this.baseUrl + "api/Repoman";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getRepoman(repo: string, parametros: IParamRepo[]): Observable<any[]> {
    return this.http.post<any[]>(this.apiURL + "/getRepoman/" + repo, parametros);
  }

}

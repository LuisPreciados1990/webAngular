import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IGestion } from '../../models/main/gestiones';


@Injectable({
  providedIn: 'root'
})
export class GestionesService {

  private apiURL = this.baseUrl + "api/Gestion";

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getGestiones(): Observable<IGestion[]> {
    return this.http.get<IGestion[]>(this.apiURL + "/GetGesti");
  }

  getGestiMenu(): Observable<any[]> {
    return this.http.get<any[]>(this.apiURL + "/getGestiMenu");
  }

}

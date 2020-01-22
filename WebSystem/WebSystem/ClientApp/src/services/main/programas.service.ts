import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IPrograma } from '../../models/main/programas';

@Injectable({
  providedIn: 'root'
})
export class ProgramasService {

  private apiURL = this.baseUrl + "api/Programa";

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getProgramas(gesti: string, tarea: string): Observable<IPrograma[]> {
    return this.http.get<IPrograma[]>(this.apiURL + "/GetByGestiTask/" + gesti + "/" + tarea);
  }
  getAllTask(): Observable<IPrograma[]> {
    return this.http.get<IPrograma[]>(this.apiURL + "/GetTask");
  }
}

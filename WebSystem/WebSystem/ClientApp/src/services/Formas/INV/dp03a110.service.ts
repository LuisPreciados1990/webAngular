import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IDp03a110 } from '../../../models/Formas/INV/dp03a110';

@Injectable({
  providedIn: 'root'
})
export class Dp03a110Service {
  private apiURL = this.baseUrl + "api/DP03A110";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  GetProductoByCodigo(codigo: string): Observable<IDp03a110> {
    return this.http.get<IDp03a110>(this.apiURL + "/GetProductoByCodigo/" + codigo);
  }

  GetProductoByNombre(nombre: string): Observable<IDp03a110[]> {
    return this.http.get<IDp03a110[]>(this.apiURL + "/GetProductoByNombre/" + nombre);
  }

  GetProductos(): Observable<IDp03a110[]> {
    return this.http.get<IDp03a110[]>(this.apiURL + "/GetProductos");
  }

  SaveItem(producto: IDp03a110): Observable<IDp03a110> {
    return this.http.post<IDp03a110>(this.apiURL + "/SaveItem", producto);
  }

  CheckNoparte(codigo: string): boolean {    
    if (this.http.get<IDp03a110>(this.apiURL + "/GetProductoByCodigo/" + codigo) === null) {
      return false
    } else {
      return true;
    }   
  }

  updateItemById(prod: IDp03a110): Observable<IDp03a110> {
    return this.http.put<IDp03a110>(this.apiURL + "/updateItem/" + prod.id, prod);
  }

}

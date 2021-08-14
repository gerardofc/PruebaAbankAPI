import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { OrdenDetalle } from '../models/OrdenDetalle';

@Injectable({
  providedIn: 'root'
})
export class OrdendetalleService {
  myApUrl='https://localhost:44331/';
  myApiUrl='api/OrdenDetalle/agregarsku';
  myApiUrl2='api/OrdenDetalle';
  myApiUrl3='api/OrdenDetalle/cancelarorden/';
  listar: OrdenDetalle[] = [];

  constructor(private http: HttpClient) { }
    ObtenerListaOrden(){
      this.http.get(this.myApUrl+this.myApiUrl2).toPromise()
                    .then(data =>{
                      this.listar = data as OrdenDetalle[];
                    })
    }
    CancelarOrden(id_orden: string): Observable<OrdenDetalle>{
      return this.http.get(this.myApUrl+ this.myApiUrl3+id_orden);
    }
}

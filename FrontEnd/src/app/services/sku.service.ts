import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Sku } from '../models/Sku';

@Injectable({
  providedIn: 'root'
})
export class SKUService {
  myApUrl='https://localhost:44331/';
  myApiUrl='api/SKU/agregarsku';
  myApiUrl2='api/SKU';
  myApiUrl3='api/SKU/eliminarsku/';
  listar: Sku[] = [];
  constructor(private http: HttpClient) { }
  agregarsku(sku:Sku): Observable<Sku>{
    return this.http.post<Sku>(this.myApUrl + this.myApiUrl,sku)
  }
  ObtenerListaSKU(){
    this.http.get(this.myApUrl+this.myApiUrl2).toPromise()
                  .then(data =>{
                    this.listar = data as Sku[];
                  })
  }
  EliminarSKU(id_sku: string): Observable<Sku>{
    return this.http.get(this.myApUrl+ this.myApiUrl3+id_sku);
  }

}

import { environment } from './../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Shipper } from '../models/shipper';
import { Observable, of } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ShippersService {


  endpoint: string = 'ShippersApi';
  constructor(private http: HttpClient) { }

  public crearShipper(shippersRequest: Shipper): Observable<any>{
    let url = environment.apiShippers + this.endpoint;
    return this.http.post(url, shippersRequest);
  }

  public getShippers(): Observable<Array<Shipper>>{
    let url = environment.apiShippers + this.endpoint;
    return this.http.get<Array<Shipper>>(url);
  }

  public modificarShipper(shippersRequest: Shipper): Observable<any>{
    let url = environment.apiShippers + this.endpoint;
    return this.http.put(url, shippersRequest);
  }

  public borrarShipper(ship: Shipper): Observable<any>{
    let url = environment.apiShippers + this.endpoint + `/${ship.ShipperID}`;
    return this.http.delete(url)
  }
}

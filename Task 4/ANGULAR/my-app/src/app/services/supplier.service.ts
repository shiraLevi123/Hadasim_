import { Injectable } from '@angular/core';
import { Supplier } from '../models/supplier.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';


@Injectable({
  providedIn: 'root'
})
export class SupplierService {
  private basicUrl = 'https://localhost:7075/api/Supplier'

  constructor(
    private _http: HttpClient,
    private _router: Router,

  ) { }

  login(companyName: string, password: string): Observable<Supplier> {
    return this._http.post<Supplier>(`${this.basicUrl}/login`, { companyName, password });
  }
  register(supplier: Supplier): Observable<Supplier> { 
    return this._http.post<Supplier>(`${this.basicUrl}/register`, supplier);
  }
}

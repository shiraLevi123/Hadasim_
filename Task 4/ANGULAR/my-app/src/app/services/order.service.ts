import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Order } from '../models/order.model';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private basicUrl = 'https://localhost:7075/api/Orders';


  constructor(private http: HttpClient, private router: Router) {}

  getOrdersBySupplier(supplierId: number): Observable<Order[]> {
    return this.http.get<Order[]>(`${this.basicUrl}/by-supplier/${supplierId}`);
  }

  approveOrder(orderId: number): Observable<any> {
    return this.http.post(`${this.basicUrl}/${orderId}/approve`, {});
  }


}
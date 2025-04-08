import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Component } from '@angular/core';
import { Order } from '../../../models/order.model';
import { OrderService } from '../../../services/order.service';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-orders',
  imports: [CommonModule,RouterModule],
  templateUrl: './orders.component.html',
  styleUrl: './orders.component.css'
})
export class OrdersComponent {
  orders: Order[] = [];
  supplierId = Number(localStorage.getItem('supplierId')) || 0;

  constructor(private _orderService: OrderService, private router: Router) { }

  ngOnInit(): void {    
    this._orderService.getOrdersBySupplier(this.supplierId).subscribe({
      next: (data) => {
        this.orders = data
      },
      error: (err) => console.error('שגיאה בטעינת הזמנות', err)
    });
  }

  approve(orderId: number): void {    
    this._orderService.approveOrder(orderId).subscribe(() => {
      const order = this.orders.find(o => o.id === orderId);
      if (order) order.status = false;
    });
  }

  getStatus(status: boolean): string {
    switch (status) {
      case null: return 'ממתינה';
      case false: return 'בתהליך';
      case true: return 'הושלמה';
      default: return 'לא ידוע';
    }
  }
}
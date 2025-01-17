import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable, of, switchMap } from 'rxjs';


export interface Order {
  id: string;
  userId: string;
  items: CartItem[];
}
export interface CartItem {
  productId: string;
  quantity: number;
}

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private apiUrl = 'https://localhost:7198/api/Order';

  constructor(private http: HttpClient) { }

  // Create a new Cart
  public createOrder(userId: string, productsToOrder: CartItem[]): Observable<Order> {
    const body = { userId, productsToOrder };
    return this.http.post<Order>(`${this.apiUrl}`, body);
  }
}
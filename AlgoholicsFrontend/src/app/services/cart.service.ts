import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  private cartItems: any[] = [
    { name: 'Smartwatch', price: 100, qty: 1, image: 'assets/product01.png' },
    { name: 'Headphones', price: 150, qty: 2, image: 'assets/product02.png' },
    { name: 'Mouse', price: 50, qty: 1, image: 'assets/product03.png' }
  ];

  cartItemsChanged: BehaviorSubject<any[]> = new BehaviorSubject(this.cartItems);

  getCart(): any[] {
    return this.cartItems;
  }

  addToCart(product: any): void {
    const existingProduct = this.cartItems.find(item => item.name === product.name);
    if (existingProduct) {
      existingProduct.qty += 1; 
    } else {
      product.qty = 1; 
      this.cartItems.push(product);
    }
    this.cartItemsChanged.next(this.cartItems); 
  }

  updateCart(items: any[]): void {
    this.cartItems = items;
    this.cartItemsChanged.next(this.cartItems);
  }

  getCartItemCount(): number {
    return this.cartItems.length;
  }

  removeFromCart(productId: number): void {
    this.cartItems = this.cartItems.filter(product => product.id !== productId);
  }
}

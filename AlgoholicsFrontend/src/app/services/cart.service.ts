import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  private cartKey = 'cartItems';

  constructor() { }

  // ✅ Retrieve all cart items (full product objects)
  getCartItems(): any[] {
    return JSON.parse(localStorage.getItem(this.cartKey) || '[]');
  }

  // ✅ Get the total count of items in the cart
  getCartItemCount(): number {
    return this.getCartItems().length;  // ✅ Returns the correct count
  }

  // ✅ Add a product to the cart
  addToCart(product: any): void {
    let cartItems = this.getCartItems();
    cartItems.push(product);
    localStorage.setItem(this.cartKey, JSON.stringify(cartItems));
  }

  // ✅ Remove a product from the cart
  removeFromCart(productId: number): void {
    let cartItems = this.getCartItems().filter(item => item.id !== productId);
    localStorage.setItem(this.cartKey, JSON.stringify(cartItems));
  }

  // ✅ Clear cart
  clearCart(): void {
    localStorage.removeItem(this.cartKey);
  }
}

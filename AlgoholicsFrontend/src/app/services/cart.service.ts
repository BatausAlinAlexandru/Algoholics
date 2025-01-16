import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  private cartKey = 'cartItems';

  constructor() { }

  // Get cart items from localStorage
  getCartItems(): any[] {
    const items = localStorage.getItem(this.cartKey);
    return items ? JSON.parse(items) : [];
  }

  getCartItemCount(): number {
    return this.getCartItems().reduce((sum, item) => sum + item.quantity, 0);  // ✅ Returns the correct count
  }

  // Add product to cart
  addToCart(product: any) {
    let cart = this.getCartItems();
    const existingProduct = cart.find(item => item.id === product.id);

    if (existingProduct) {
      existingProduct.quantity++; // Increase quantity if already in cart
    } else {
      cart.push({ ...product, quantity: 1 });
    }

    localStorage.setItem(this.cartKey, JSON.stringify(cart)); // Update localStorage
  }

  // Remove product from cart
  removeFromCart(productId: number) {
    let cart = this.getCartItems().filter(item => item.id !== productId);
    localStorage.setItem(this.cartKey, JSON.stringify(cart));
  }

  // Clear the cart
  clearCart() {
    localStorage.removeItem(this.cartKey);
  }

  

}

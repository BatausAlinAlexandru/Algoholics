import { Component, OnInit } from '@angular/core';
import { CartService } from '../../services/cart.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  cartItems: any[] = [];

  constructor(private cartService: CartService) { }

  ngOnInit() {
    this.loadCart();
  }

  loadCart() {
    this.cartItems = this.cartService.getCartItems();
  }

  calculateTotal(): number {
    let total = 0;

    this.cartItems.forEach(item => {
      // Validate price and quantity
      if (item.price > 0 && !isNaN(item.price) && item.quantity > 0 && !isNaN(item.quantity)) {
        total += item.price * item.quantity;  // Use 'quantity' instead of 'qty'
      }
    });

    return total;
  }


  removeItem(id: number) {
    this.cartService.removeFromCart(id);
    this.loadCart(); // Refresh cart display
  }

  clearCart() {
    this.cartService.clearCart();
    this.loadCart();
  }
}

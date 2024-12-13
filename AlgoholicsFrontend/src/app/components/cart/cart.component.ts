import { Component, OnInit } from '@angular/core';
import { CartService } from '../../services/cart.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  cartItems: any[] = [];
  cartTotal: number = 0;

  constructor(private cartService: CartService) { }

  ngOnInit(): void {
    this.cartItems = this.cartService.getCart();
    this.calculateTotal();
  }

  calculateTotal(): number {
    let total = 0;
    this.cartItems.forEach(item => {
      total += item.price * item.qty;
    });
    return total;
  }

  removeFromCart(product: any): void {
    this.cartItems = this.cartItems.filter(item => item !== product);
    this.cartService.updateCart(this.cartItems); 
    this.calculateTotal(); 
  }

}

import { Component, OnInit } from '@angular/core';
import { CartService } from '../../services/cart.service';

interface Product {
  id: number;
  name: string;
  price: number;
}

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  cartProducts: Product[] = [];
  allProducts: Product[] = [
    { id: 1, name: 'Product 1', price: 20 },
    { id: 2, name: 'Product 2', price: 30 },
    { id: 3, name: 'Product 3', price: 40 }
  ];

  constructor(private cartService: CartService) { }

  ngOnInit(): void {
    this.loadCartItems();
  }

  loadCartItems() {
    const cartIds = this.cartService.getCartItems();
    this.cartProducts = this.allProducts.filter(product => cartIds.includes(product.id));
  }

  removeFromCart(productId: number) {
    this.cartService.removeFromCart(productId);
    this.loadCartItems();
  }

  clearCart() {
    this.cartService.clearCart();
    this.cartProducts = [];
  }
}

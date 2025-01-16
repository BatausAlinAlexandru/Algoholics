// import { Component, OnInit } from '@angular/core';
// import { CartService } from '../../services/cart.service';

// @Component({
//   selector: 'app-cart',
//   templateUrl: './cart.component.html',
//   styleUrls: ['./cart.component.css']
// })
// export class CartComponent implements OnInit {
//   cartItems: any[] = [];
//   cartTotal: number = 0;

//   constructor(private cartService: CartService) { }

//   ngOnInit(): void {
//     this.cartItems = this.cartService.getCart();
//     this.calculateTotal();
//   }

//   calculateTotal(): number {
//     let total = 0;
//     this.cartItems.forEach(item => {
//       total += item.price * item.qty;
//     });
//     return total;
//   }

//   removeFromCart(product: any): void {
//     this.cartItems = this.cartItems.filter(item => item !== product);
//     this.cartService.updateCart(this.cartItems); 
//     this.calculateTotal(); 
//   }

// }

import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { CartService, Cart, CartItem } from '../../services/cart.service';
import { AuthService } from '../../services/auth.service';
import { HttpClient } from '@angular/common/http';
import { ProductService, Product } from '../../services/product.service';
import { forkJoin } from 'rxjs';


@Component({
    selector: 'app-cart',
    templateUrl: './cart.component.html',
    styleUrls: ['./cart.component.css']
  })
export class CartComponent implements OnInit {
  cart: Cart | null = null;
  products_of_cart: Product[] | null = null;
  loggedInUserId: string = '';
  searchTerm: string = '';

  constructor(
    private cartService: CartService,
    private productService: ProductService,
    private authService: AuthService,
    private http: HttpClient
  ) { }

  ngOnInit(): void {
    this.fetchCart();
  }
  
  fetchCart(): void {
    this.loggedInUserId = this.authService.getUserIdFromToken();
    this.cartService.getCartByUserId(this.loggedInUserId).subscribe(
      (data) => {
        console.log('Fetched cart:', data);
        this.cart = data;
        console.log('Fetched cart:', this.cart);
        this.loadCartProducts();
      },
      (error) => {
        console.error('Error fetching cart!', error);
      }
    );
  }
  
  loadCartProducts(): void {
    if (
      this.cart &&
      Array.isArray(this.cart.items) &&
      this.cart.items.length > 0
    ) {
      const productRequests = this.cart.items.map((cartItem: CartItem) => {
        console.log(cartItem);
        return this.productService.getProductById(cartItem.productId);
      });
  
      forkJoin(productRequests).subscribe(
        (items: Product[]) => {
          this.products_of_cart = items;
          console.log('All products loaded:', this.products_of_cart);
        },
        (error) => {
          console.error('Error loading products for cart!', error);
        }
      );
    } else {
      console.log('No products array found or it is empty!');
    }
  }

  removeFromCart(product: Product): void {
    if (this.cart) {
      const updatedProductsIdList = this.cart.items.filter((p) => p.productId !== product.id);
      this.cartService.updateCart(this.cart.userAccountId, updatedProductsIdList).subscribe(
        (updatedCart) => {
          this.fetchCart();
        },
        (error) => {
          console.error('Error removing product from cart', error);
        }
      );
    }
  }


}
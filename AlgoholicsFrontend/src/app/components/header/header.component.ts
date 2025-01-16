import { Component, OnInit } from '@angular/core';
import { WishlistService } from '../../services/wishlist.service';
import { CartService } from '../../services/cart.service';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit{
[x: string]: any;
  cartItems: any[] = [];
  wishlistItems: any[] = [];
  wishlistLength: any;
  cartLength: any;
  loggedInUserId: string = '';

  isCartOpen: boolean = false;
  isAuthenticated = false;

  constructor(
    private wishlistService: WishlistService,
    private cartService: CartService,
    private authService: AuthService)
  {}

  ngOnInit(): void {
    this.loggedInUserId = this.authService.getUserIdFromToken();
    this.isAuthenticated = this.authService.isAuthenticated();
    this.wishlistService.getWishlistCount(this.loggedInUserId).subscribe(
      (count: number) => {
        this.wishlistLength = count;
      },
      (error) => {
        console.error('Error fetching wishlist count', error);
        this.wishlistLength = 0; // Handle error case
      }
    )
    this.cartService.getCartCount(this.loggedInUserId).subscribe(
      (count: number) => {
        this.cartLength = count;
      },
      (error) => {
        console.error('Error fetching cart count', error);
        this.cartLength = 0; // Handle error case
      }
    )
  }

  addToWishlist(product: any): void {
    // this.wishlistService.addToWishlist(product); 
  }

  removeFromCart(product: any): void {
    // this.cartService.removeFromCart(product.id);
    // this.cartItems = this.cartService.getCart(); 
  }

  // calculateTotal(): number {
  //   return this.cartItems.reduce((total, item) => total + item.price, 0);
  // }

  
}

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

  isCartOpen: boolean = false;
  isAuthenticated = false;

  constructor(
    private wishlistService: WishlistService,
    private cartService: CartService,
    private authService: AuthService)
  {}

  ngOnInit(): void {
    this.wishlistItems = this.wishlistService.getWishlist();
    this.cartItems = this.cartService.getCartItems();
    this.isAuthenticated = this.authService.isAuthenticated();
  }

  addToWishlist(product: any): void {
    this.wishlistService.addToWishlist(product); 
  }

  getWishlistCount(): number {
    return this.wishlistService.getWishlistCount();
  }

  removeFromCart(product: any): void {
    this.cartService.removeFromCart(product.id);
    this.cartItems = this.cartService.getCartItems(); 
  }

  calculateTotal(): number {
    return this.cartItems.reduce((total, item) => total + item.price, 0);
  }

  getCartlistCount(): number {
    try {
      const count = this.cartService.getCartItemCount();
      return count > 0 ? count : 0;
    } catch (error) {
      console.error('Error fetching cart count:', error);
      return 0;
    }
  }

  
}

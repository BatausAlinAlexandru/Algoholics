import { Component, OnInit } from '@angular/core';
import { WishlistService } from '../../services/wishlist.service';
import { CartService } from '../../services/cart.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  cartItems: any[] = [];  // ✅ Ensure it's an array of products, not just IDs
  wishlistItems: any[] = [];

  isCartOpen: boolean = false;

  constructor(private wishlistService: WishlistService, private cartService: CartService) { }

  ngOnInit(): void {
    this.loadCart();
    this.wishlistItems = this.wishlistService.getWishlist();
  }

  // ✅ Fetch products from cart service
  loadCart(): void {
    this.cartItems = this.cartService.getCartItems();
  }

  addToWishlist(product: any): void {
    this.wishlistService.addToWishlist(product);
  }

  getWishlistCount(): number {
    return this.wishlistService.getWishlistCount();
  }

  removeFromCart(productId: number): void {
    this.cartService.removeFromCart(productId);
    this.loadCart();  // ✅ Reload cart after removing
  }

  calculateTotal(): number {
    return this.cartItems.reduce((total, item) => total + item.price, 0);
  }

  getCartCount(): number {
    try {
      const count = this.cartService.getCartItemCount();
      return count > 0 ? count : 0;
    } catch (error) {
      return 0;
    }
  }
}

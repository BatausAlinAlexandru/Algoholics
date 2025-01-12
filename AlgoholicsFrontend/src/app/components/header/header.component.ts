import { Component, OnInit } from '@angular/core';
import { WishlistService } from '../../services/wishlist.service';
import { CartService } from '../../services/cart.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit{
  cartItems: any[] = [];
  wishlistItems: any[] = [];

  isCartOpen: boolean = false;

  constructor(private wishlistService: WishlistService,
    private cartService: CartService)
  {}

  ngOnInit(): void {
    //this.wishlistItems = this.wishlistService.getAllWishlists();
    //this.cartItems = this.cartService.getCart();
  }

  //addToWishlist(product: any): void {
  //  this.wishlistService.addToWishlist(product); 
  //}

  //getWishlistCount(): number {
  //  return this.wishlistService.getWishlistCount();
  //}

  removeFromCart(product: any): void {
    this.cartService.removeFromCart(product.id);
    this.cartItems = this.cartService.getCart(); 
  }

  calculateTotal(): number {
    return this.cartItems.reduce((total, item) => total + item.price, 0);
  }

  getCartlistCount(): number {
      return this.cartService.getCartItemCount();
  }

  
}

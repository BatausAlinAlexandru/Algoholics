import { Component, OnInit } from '@angular/core';
import { WishlistService } from '../../services/wishlist.service';
import { CartService } from '../../services/cart.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit{
  cartItems: any[] = []; // Lista de produse din coș

  cartItemCount: number = 0;

  constructor(private wishlistService: WishlistService,
    private cartService: CartService)
  {
    this.cartService.cartItemsChanged.subscribe((items: any[]) => {
      this.cartItemCount = items.length;
    });

    this.cartItemCount = this.cartService.getCartItemCount();
  }

  ngOnInit(): void {
    // Obține produsele din coș atunci când componenta este inițializată
    this.cartItems = this.cartService.getCart();
  }

  addToWishlist(product: any): void {
    this.wishlistService.addToWishlist(product); // Adaugă produsul la wishlist
  }

  getWishlistCount(): number {
    return this.wishlistService.getWishlistCount(); // Returnează numărul de produse
  }

  removeFromCart(product: any): void {
    // Elimină produsul din coș
    this.cartService.removeFromCart(product.id);
    this.cartItems = this.cartService.getCart(); // Actualizează lista produselor din coș
  }

  calculateTotal(): number {
    // Calculează suma totală a produselor din coș
    return this.cartItems.reduce((total, item) => total + item.price, 0);
  }

  getCartlistCount(): number {
    return this.cartService.getCartItemCount(); // Returnează numărul de produse
  }
}

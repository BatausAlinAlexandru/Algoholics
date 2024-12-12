import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class WishlistService {
  private wishlist: any[] = [];

  addToWishlist(product: any): void {
    const alreadyInWishlist = this.wishlist.some(item => item.name === product.name);
    if (!alreadyInWishlist) {
      this.wishlist.push(product);
    }
    console.log('Current wishlist:', this.wishlist);

  }

  getWishlist(): any[] {
    return this.wishlist; 
  }

  getWishlistCount(): number {
    return this.wishlist.length; 
  }

  removeFromWishlist(productId: number): void {
    this.wishlist = this.wishlist.filter(product => product.id !== productId);
  }

  updateWishlist(updatedWishlist: any[]): void {
    this.wishlist = updatedWishlist;
  }
}

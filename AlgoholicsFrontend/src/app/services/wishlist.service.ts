import { Injectable } from '@angular/core';
import { ProductService } from './product.service';

@Injectable({
  providedIn: 'root'
})
export class WishlistService {
  private wishlist: any[] = [];
  //  { name: 'Laptop', description: 'Description 1', price: 100 },
  //  { name: 'Camera', description: 'Description 2', price: 200 },
  //  { name: 'Smartphone', description: 'Description 3', price: 300 }
  //];

  constructor(private productService: ProductService) { }

  addToWishlist(productId: number): void {
    //const alreadyInWishlist = this.wishlist.some(item => item.name === product.name);
    //if (!alreadyInWishlist) {
    //  this.wishlist.push(product);
    //}
    //console.log('Current wishlist:', this.wishlist);
    const product = this.productService.products.find(p => p.id === productId);
    if (product) {
      const alreadyInWishlist = this.wishlist.some(item => item.id === product.id);
      if (!alreadyInWishlist) {
        this.wishlist.push(product);
      }
    }
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

  //isWishlistOpen(): string {
  //  return this.isWishlistOpen().valueOf();
     
  //}
}

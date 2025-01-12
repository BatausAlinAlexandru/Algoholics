//import { Injectable } from '@angular/core';

//@Injectable({
//  providedIn: 'root'
//})
//export class WishlistService {
//  private wishlist: any[] = [
//    { name: 'Laptop', description: 'Description 1', price: 100 },
//    { name: 'Camera', description: 'Description 2', price: 200 },
//    { name: 'Smartphone', description: 'Description 3', price: 300 }
//  ];

//  addToWishlist(product: any): void {
//    const alreadyInWishlist = this.wishlist.some(item => item.name === product.name);
//    if (!alreadyInWishlist) {
//      this.wishlist.push(product);
//    }
//    console.log('Current wishlist:', this.wishlist);

//  }

//  getWishlist(): any[] {
//    return this.wishlist; 
//  }

//  getWishlistCount(): number {
//    return this.wishlist.length; 
//  }

//  removeFromWishlist(productId: number): void {
//    this.wishlist = this.wishlist.filter(product => product.id !== productId);
//  }

//  updateWishlist(updatedWishlist: any[]): void {
//    this.wishlist = updatedWishlist;
//  }

//  //isWishlistOpen(): string {
//  //  return this.isWishlistOpen().valueOf();
     
//  //}
//}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Product {
  id: string;
  name: string;
  description: string;
  price: number;
  quantity: number;
}

export interface Wishlist {
  id: string;
  userAccountId: string;
  products: Product[];
}

@Injectable({
  providedIn: 'root'
})
export class WishlistService {
  private apiUrl = 'https://localhost:7198/api/Wishlist';

  constructor(private http: HttpClient) { }

  // Get all wishlists
  public getAllWishlists(): Observable<Wishlist[]> {
    return this.http.get<Wishlist[]>(`${this.apiUrl}`);
  }

  // Get a specific wishlist by user ID
  public getWishlistByUserId(userAccountId: string): Observable<Wishlist> {
    return this.http.get<Wishlist>(`${this.apiUrl}/user/${userAccountId}`);
  }

  // Create a new wishlist
  public createWishlist(userAccountId: string, products: Product[]): Observable<Wishlist> {
    const body = { userAccountId, products };
    return this.http.post<Wishlist>(`${this.apiUrl}`, body);
  }

  // Update wishlist products
  public updateWishlist(wishlistId: string, products: Product[]): Observable<Wishlist> {
    const body = { products };
    return this.http.put<Wishlist>(`${this.apiUrl}/update-wishlist/${wishlistId}`, body);
  }

  // Remove a wishlist
  public removeWishlist(wishlistId: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${wishlistId}`);
  }
}



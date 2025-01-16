import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable, of, switchMap } from 'rxjs';

// export interface ProductDetail {
//   name: string;
//   price: number;
//   description: string;
//   stoc: number;
//   discount: number;
//   pathFoto: string;
// }

// export interface Product {
//   id: string;
//   productDetail: ProductDetail;
// }

export interface Wishlist {
  id: string;
  userAccountId: string;
  productsId: string[];
}

@Injectable({
  providedIn: 'root'
})
export class WishlistService {
  private apiUrl = 'https://localhost:7198/api/WishList';

  constructor(private http: HttpClient) { }

  // Get all wishlists
  public getAllWishlists(): Observable<Wishlist[]> {
    return this.http.get<Wishlist[]>(`${this.apiUrl}`);
  }

  // Get a specific wishlist by user ID
  public getWishlistByUserId(userAccountId: string): Observable<Wishlist> {
    return this.http.get<Wishlist>(`${this.apiUrl}/get-wishlist-user/${userAccountId}`);
  }

  // Create a new wishlist
  public createWishlist(userAccountId: string, productId: string[]): Observable<Wishlist> {
    const body = { userAccountId, productId };
    return this.http.post<Wishlist>(`${this.apiUrl}/add`, body);
  }

  public addProductToWishlist(userAccountId: string, productId: string): Observable<Wishlist> {
    return this.getWishlistByUserId(userAccountId).pipe(
      switchMap((wishlist: Wishlist) => {
        if (!wishlist) {
          // If no wishlist found, create a brand-new one with this product ID
          return this.createWishlist(userAccountId, [productId]);
        } else {
          // If wishlist exists, check if product is already in the list
          const alreadyInWishlist = wishlist.productsId.includes(productId);
          if (alreadyInWishlist) {
            // Nothing to do, just return the existing wishlist as an observable
            return of(wishlist);
          } else {
            // Product is not in wishlist, so we add it
            const updatedIds = [...wishlist.productsId, productId];
            return this.updateWishlist(userAccountId, updatedIds);
          }
        }
      })
    );
  }

  // Update wishlist products
  public updateWishlist(idUserAccount: string, products: string[]): Observable<Wishlist> {
    const body = { idUserAccount,products };
    return this.http.put<Wishlist>(`${this.apiUrl}/update`, body);
  }

  // Remove a wishlist
  public removeWishlist(wishlistId: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${wishlistId}`);
  }

  public getWishlistCount(userAccountId: string): Observable<number> {
    return this.getWishlistByUserId(userAccountId).pipe(
      map((wishlist: Wishlist) => wishlist.productsId.length)
    );
  }
}
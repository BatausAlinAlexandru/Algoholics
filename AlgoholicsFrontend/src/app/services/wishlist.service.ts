// wishlist.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable, of, switchMap, BehaviorSubject } from 'rxjs';

export interface Wishlist {
  id: string;
  userAccountId: string;
  productsId: string[];
}

@Injectable({
  providedIn: 'root'
})
export class WishlistService {
  private apiUrl = 'https://localhost:32771/api/WishList';

  // 1) BehaviorSubject to hold the current wishlist count
  private wishlistCountSubject = new BehaviorSubject<number>(0);
  // Expose it as an Observable to allow subscription
  public wishlistCount$ = this.wishlistCountSubject.asObservable();

  constructor(private http: HttpClient) {}

  // --- CRUD Methods ---
  
  public getWishlistByUserId(userAccountId: string): Observable<Wishlist> {
    return this.http.get<Wishlist>(`${this.apiUrl}/get-wishlist-user/${userAccountId}`);
  }

  public createWishlist(userAccountId: string, productIds: string[]): Observable<Wishlist> {
    const body = { userAccountId, productId: productIds };
    return this.http.post<Wishlist>(`${this.apiUrl}/add`, body);
  }

  public addProductToWishlist(userAccountId: string, productId: string): Observable<Wishlist> {
    return this.getWishlistByUserId(userAccountId).pipe(
      switchMap((wishlist: Wishlist) => {
        if (!wishlist) {
          // If no wishlist found, create a new one
          return this.createWishlist(userAccountId, [productId]);
        } else {
          // If wishlist exists, check if product is already in the list
          const alreadyInWishlist = wishlist.productsId.includes(productId);
          if (alreadyInWishlist) {
            // Nothing to do; return the existing wishlist
            return of(wishlist);
          } else {
            // Add new product to the existing list
            const updatedIds = [...wishlist.productsId, productId];
            return this.updateWishlist(userAccountId, updatedIds);
          }
        }
      })
    );
  }

  public updateWishlist(userAccountId: string, products: string[]): Observable<Wishlist> {
    const body = { idUserAccount: userAccountId, products };
    return this.http.put<Wishlist>(`${this.apiUrl}/update`, body);
  }

  public removeWishlist(wishlistId: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${wishlistId}`);
  }

  // --- Counting Methods ---

  /**
   * This method calls the API to get the wishlist count for a user
   */
  public getWishlistCount(userAccountId: string): Observable<number> {
    return this.getWishlistByUserId(userAccountId).pipe(
      map((wishlist: Wishlist) => {
        if (!wishlist || !wishlist.productsId) {
          return 0;
        }
        return wishlist.productsId.length;
      })
    );
  }

  /**
   * This method fetches the count and updates the `wishlistCountSubject`
   */
  public fetchWishlistCount(userAccountId: string): void {
    this.getWishlistCount(userAccountId).subscribe(
      (count) => this.wishlistCountSubject.next(count),
      (error) => {
        console.error('Error fetching wishlist count:', error);
        this.wishlistCountSubject.next(0);
      }
    );
  }
}

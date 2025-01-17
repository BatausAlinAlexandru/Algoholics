// cart.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable, of, switchMap, BehaviorSubject } from 'rxjs';

export interface Cart {
  id: string;
  userAccountId: string;
  totalPrice: number;
  items: CartItem[];
}

export interface CartItem {
  productId: string;
  quantity: number;
}

@Injectable({
  providedIn: 'root'
})
export class CartService {
  private apiUrl = 'https://localhost:7198/api/Cart';

  // 1) BehaviorSubject to hold the current cart count
  private cartCountSubject = new BehaviorSubject<number>(0);
  // Expose as an observable
  public cartCount$ = this.cartCountSubject.asObservable();

  constructor(private http: HttpClient) {}

  // --- CRUD Methods ---

  public getCartByUserId(userId: string): Observable<Cart> {
    return this.http.get<Cart>(`${this.apiUrl}/get-cart-user/${userId}`);
  }

  public createCart(userAccountId: string, items: CartItem[]): Observable<Cart> {
    const body = { userAccountId, items };
    return this.http.post<Cart>(`${this.apiUrl}/add`, body);
  }

  public addProductToCart(userAccountId: string, item: CartItem): Observable<Cart> {
    return this.getCartByUserId(userAccountId).pipe(
      switchMap((cart: Cart) => {
        if (!cart) {
          // If no cart found, create a brand-new one
          return this.createCart(userAccountId, [item]);
        } else {
          // Check if product is already in cart
          const itemAlreadyInCart = cart.items.some(i => i.productId === item.productId);
          if (itemAlreadyInCart) {
            // No action if already in cart
            return of(cart);
          } else {
            // Add the new item
            const updatedItems = [...cart.items, item];
            return this.updateCart(userAccountId, updatedItems);
          }
        }
      })
    );
  }

  public updateCart(userAccountId: string, items: CartItem[]): Observable<Cart> {
    const body = { userAccountId, items };
    return this.http.put<Cart>(`${this.apiUrl}/update`, body);
  }

  public removeCart(cartId: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/delete/${cartId}`);
  }

  // --- Counting Methods ---

  public getCartCount(userAccountId: string): Observable<number> {
    return this.getCartByUserId(userAccountId).pipe(
      map((cart: Cart) => {
        if (!cart || !cart.items) {
          return 0;
        }
        return cart.items.length;
      })
    );
  }

  public fetchCartCount(userAccountId: string): void {
    this.getCartCount(userAccountId).subscribe(
      (count) => this.cartCountSubject.next(count),
      (error) => {
        console.error('Error fetching cart count:', error);
        this.cartCountSubject.next(0);
      }
    );
  }
}

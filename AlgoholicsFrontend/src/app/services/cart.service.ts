// import { Injectable } from '@angular/core';
// import { BehaviorSubject } from 'rxjs';

// @Injectable({
//   providedIn: 'root',
// })
// export class CartService {
//   private cartItems: any[] = [
//     { name: 'Smartwatch', price: 100, qty: 1, image: 'assets/product01.png' },
//     { name: 'Headphones', price: 150, qty: 2, image: 'assets/product02.png' },
//     { name: 'Mouse', price: 50, qty: 1, image: 'assets/product03.png' }
//   ];

//   cartItemsChanged: BehaviorSubject<any[]> = new BehaviorSubject(this.cartItems);

//   getCart(): any[] {
//     return this.cartItems;
//   }

//   addToCart(product: any): void {
//     const existingProduct = this.cartItems.find(item => item.name === product.name);
//     if (existingProduct) {
//       existingProduct.qty += 1; 
//     } else {
//       product.qty = 1; 
//       this.cartItems.push(product);
//     }
//     this.cartItemsChanged.next(this.cartItems); 
//   }

//   updateCart(items: any[]): void {
//     this.cartItems = items;
//     this.cartItemsChanged.next(this.cartItems);
//   }

//   getCartItemCount(): number {
//     return this.cartItems.length;
//   }

//   removeFromCart(productId: number): void {
//     this.cartItems = this.cartItems.filter(product => product.id !== productId);
//   }
// }

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable, of, switchMap } from 'rxjs';


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

  constructor(private http: HttpClient) { }

  // Get all Carts
  public getAllCarts(): Observable<Cart[]> {
    return this.http.get<Cart[]>(`${this.apiUrl}`);
  }

  // Get a specific Cart by user ID
  public getCartByUserId(userId: string): Observable<Cart> {
    return this.http.get<Cart>(`${this.apiUrl}/get-cart-user/${userId}`);
  }

  // Create a new Cart
  public createCart(userAccountId: string, items: CartItem[]): Observable<Cart> {
    const body = { userAccountId, items };
    return this.http.post<Cart>(`${this.apiUrl}/add`, body);
  }

  public addProductToCart(userAccountId: string, item: CartItem): Observable<Cart> {
    return this.getCartByUserId(userAccountId).pipe(
      switchMap((Cart: Cart) => {
        if (!Cart) {
          // If no Cart found, create a brand-new one with this product ID
          return this.createCart(userAccountId, [item]);
        } else {
          // If Cart exists, check if product is already in the list
          const itemAlreadyInCart = Cart.items.some(
            (cartItem) => cartItem.productId === item.productId
          );
          console.log(itemAlreadyInCart);
          if (itemAlreadyInCart) {
            // Nothing to do, just return the existing Cart as an observable
            return of(Cart);
          } else {
            // Product is not in Cart, so we add it
            const items = [...Cart.items, item];
            return this.updateCart(userAccountId, items);
          }
        }
      })
    );
  }

  // Update Cart products
  public updateCart(userAccountId: string, items: CartItem[]): Observable<Cart> {
    const body = { userAccountId,items };
    return this.http.put<Cart>(`${this.apiUrl}/update`, body);
  }

  // Remove a Cart
  public removeCart(cartId: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/delete/${cartId}`);
  }

  public getCartCount(userAccountId: string): Observable<number> {
    return this.getCartByUserId(userAccountId).pipe(
      map((cart: Cart) => cart.items.length)
    );
  }
}
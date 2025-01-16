import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { CartService } from '../../services/cart.service';
import { WishlistService } from '../../services/wishlist.service';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {
  
  products: any[] = [];
  loggedInUserId: string = '';

  // 1) States for tracking the wishlist icon and success animation
  isWishlistActive: { [productId: number]: boolean } = {};
  showWishlistSuccess: { [productId: number]: boolean } = {};
  isCartActive: { [productId: number]: boolean } = {};
  showCartSuccess: { [productId: number]: boolean } = {};

  constructor(
    private productService: ProductService,
    private cartService: CartService,
    private wishlistService: WishlistService,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.productService.getAllProducts().subscribe(
      (data: any) => {
        this.products = data as any[];
      },
      (error) => {
        console.error('Error fetching products:', error);
      }
    );

    this.loggedInUserId = this.authService.getUserIdFromToken();
  }

  // addToCart(id: number): void {
  //   this.cartService.addToCart(id);
  // }

  addToCart(product: any): void {
    this.isCartActive[product.id] = true;
  
    // Build the CartItem properly:
    const cartItem = {
      productId: product.id,      // or product.productId if that's the actual property
      quantity: product.quantity || 1  // If product doesn't have a quantity, default to 1
    };
  
    this.cartService.addProductToCart(this.loggedInUserId, cartItem).subscribe(
      (updatedCart) => {
        console.log('Product added to cart', updatedCart);
  
        // Trigger the checkmark animation
        this.showCartSuccess[product.id] = true;
  
        // Hide the checkmark after 1 second (adjust time as you wish)
        setTimeout(() => {
          this.showCartSuccess[product.id] = false;
        }, 1100);
      },
      (error) => {
        console.error('Error adding to cart', error);
        // If there was an error, revert the fill
        this.isCartActive[product.id] = false;
      }
    );
  }

  addToWishlist(product: any): void {
    this.isWishlistActive[product.id] = true;

    this.wishlistService.addProductToWishlist(this.loggedInUserId, product.id).subscribe(
      (updatedWishlist) => {
        console.log('Product added to wishlist', updatedWishlist);

        // Trigger the checkmark animation
        this.showWishlistSuccess[product.id] = true;

        // Hide the checkmark after 1 second (adjust time as you wish)
        setTimeout(() => {
          this.showWishlistSuccess[product.id] = false;
        }, 1100);
      },
      (error) => {
        console.error('Error adding to wishlist', error);
        // If there was an error, revert the fill
        this.isWishlistActive[product.id] = false;
      }
    );
  }

  viewProduct(id: number): void {
    this.router.navigate(['/product-details', id]);
  }
}


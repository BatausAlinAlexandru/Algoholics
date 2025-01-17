import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { WishlistService, Wishlist } from '../../services/wishlist.service';
import { AuthService } from '../../services/auth.service';
import { HttpClient } from '@angular/common/http';
import { ProductService, Product } from '../../services/product.service';
import { forkJoin } from 'rxjs';


@Component({
  selector: 'app-wishlist',
  templateUrl: './wishlist.component.html',
  styleUrls: ['./wishlist.component.css'],
})
export class WishlistComponent implements OnInit {
  wishlist: Wishlist | null = null;
  products_of_wishlist: Product[] | null = null;
  loggedInUserId: string = ''; // Assume this is retrieved from a token or authentication service
  searchTerm: string = '';

  constructor(
    private wishlistService: WishlistService,
    private productService: ProductService,
    private authService: AuthService,
    private http: HttpClient
  ) { }

  ngOnInit(): void {
    this.fetchWishlist();
  }
  
  fetchWishlist(): void {
    this.loggedInUserId = this.authService.getUserIdFromToken();
    this.wishlistService.getWishlistByUserId(this.loggedInUserId).subscribe(
      (data) => {
        console.log('Fetched wishlist:', data);
        this.wishlist = data;
        console.log('Fetched wishlist:', this.wishlist);
        this.loadWishlistProducts();
      },
      (error) => {
        console.error('Error fetching wishlist!', error);
      }
    );
  }
  
  loadWishlistProducts(): void {
    // Make sure `wishlist` is not null, `products` exists, and is an array with length
    if (
      this.wishlist &&
      Array.isArray(this.wishlist.productsId) &&
      this.wishlist.productsId.length > 0
    ) {
      const productRequests = this.wishlist.productsId.map((productId) =>
        this.productService.getProductById(productId)
      );
  
      forkJoin(productRequests).subscribe(
        (products: Product[]) => {
          this.products_of_wishlist = products;
          console.log('All products loaded:', this.products_of_wishlist);
        },
        (error) => {
          console.error('Error loading products for wishlist!', error);
        }
      );
    } else {
      console.log('No products array found or it is empty!');
    }
  }

  removeFromWishlist(product: Product): void {
    if (this.wishlist) {
      const updatedProductsIdList = this.wishlist.productsId.filter((p) => p !== product.id);
      this.wishlistService.updateWishlist(this.wishlist.userAccountId, updatedProductsIdList).subscribe(
        (updatedWishlist) => {
          this.fetchWishlist();
          this.wishlistService.fetchWishlistCount(this.loggedInUserId);
        },
        (error) => {
          console.error('Error removing product from wishlist', error);
        }
      );
    }
  }


}
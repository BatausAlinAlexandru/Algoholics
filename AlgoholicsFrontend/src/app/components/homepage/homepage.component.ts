import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { CartService } from '../../services/cart.service';
import { WishlistService } from '../../services/wishlist.service';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrl: './homepage.component.css'
})
export class HomepageComponent implements OnInit {

  products: any[] = [];

  constructor(private productService: ProductService,
    private cartService: CartService,
    private wishlistService: WishlistService,
    private router: Router) { }

  ngOnInit(): void {
    this.productService.getAllProducts().subscribe((data: any) => {
      this.products = data as any[];
    },
    (error) => {
      console.error('Error fetching products:', error);
    }
    );
  }

  addToCart(id: number): void {
    this.cartService.addToCart(id);
  }

  addToWishlist(id: number): void {
    this.wishlistService.addToWishlist(id);
  }

  viewProduct(id: number): void {
    this.router.navigate(['/product-details', id]);
  }

}

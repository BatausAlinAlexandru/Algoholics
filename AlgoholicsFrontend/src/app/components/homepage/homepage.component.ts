import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { WishlistService } from '../../services/wishlist.service';
import { Observable } from 'rxjs';
@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrl: './homepage.component.css'
})
export class HomepageComponent implements OnInit {

  products: any[] = [];

  constructor(private productService: ProductService,
    private wishlistService: WishlistService) { }

  ngOnInit(): void {
    this.productService.getAllProducts().subscribe((data: any) => {
      this.products = data as any[];
    },
    (error) => {
      console.error('Error fetching products:', error);
    }
    );
  }

  addToWishlist(product: any): void {
    //this.wishlistService.addToWishlist(product);
  }

}

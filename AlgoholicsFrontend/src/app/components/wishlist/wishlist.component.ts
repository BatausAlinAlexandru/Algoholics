import { Component, OnInit } from '@angular/core';
import { WishlistService } from '../../services/wishlist.service';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-wishlist',
  templateUrl: './wishlist.component.html',
  styleUrls: ['./wishlist.component.css']
})
export class WishlistComponent implements OnInit {

  wishlistItems: any[] = [];

  constructor(private wishlistService: WishlistService,
  private productService: ProductService) { }

  ngOnInit(): void {
    this.productService.getAllProducts().subscribe()
      this.wishlistItems = this.wishlistService.getWishlist();
    }

  removeFromWishlist(item: any): void {
    this.wishlistItems = this.wishlistItems.filter(product => product !== item);
    this.wishlistService.updateWishlist(this.wishlistItems); 
  }

  
}

import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { WishlistService } from '../../services/wishlist.service';

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
    this.productService.getAllProducts().subscribe(prods => {
      console.log(prods);
    });
  }

  addToWishlist(product: any): void {
    this.wishlistService.addToWishlist(product);
  }

}

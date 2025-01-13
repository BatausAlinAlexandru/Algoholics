import { Component, OnInit } from '@angular/core';
import { CartService } from '../../services/cart.service';

interface Product {
  id: number;
  name: string;
  price: number;
}

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  products: Product[] = [
    { id: 1, name: 'Product 1', price: 20 },
    { id: 2, name: 'Product 2', price: 30 },
    { id: 3, name: 'Product 3', price: 40 }
  ];

  constructor(private cartService: CartService) { }

  addToCart(productId: number) {
    this.cartService.addToCart(productId);
    alert('Product added to cart!');
  }

  ngOnInit(): void { }
}

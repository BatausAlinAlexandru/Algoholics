import { Component, OnInit } from '@angular/core';
import { Product, ProductService } from '../../services/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent implements OnInit {
  products: Product[] = [];
  searchTerm: string = '';
  selectedProduct: Product = {
    id: '', "name": '', "description": '',
    "stock": '', "discount": '', "price": '',
    "idCtegory": '',
  }

  constructor(private productService: ProductService) { }

  ngOnInit() {
    this.loadProducts();
  }

  get filteredProducts() {
    if (!this.searchTerm) {
      return this.products;
    }

    const lowerCaseSearchTerm = this.searchTerm.toLowerCase();
    return this.products.filter(product =>
      product.id.toLowerCase().includes(lowerCaseSearchTerm) ||
      product.name.toLowerCase().includes(lowerCaseSearchTerm) ||
      product.price.toString().includes(lowerCaseSearchTerm) ||
      product.description.toString().includes(lowerCaseSearchTerm) ||
      product.stock.toString().includes(lowerCaseSearchTerm) ||
      product.discount.toString().includes(lowerCaseSearchTerm) ||
      product.idCtegory.toString().includes(lowerCaseSearchTerm)
    );
  }



  loadProducts() {
    this.productService.getProducts().subscribe((data) => {
      console.log(data);
      this.products = data;
    });
  }
}

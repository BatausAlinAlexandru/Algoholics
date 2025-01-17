import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-product-page',
  templateUrl: './product-page.component.html',
  styleUrl: './product-page.component.css'
})
export class ProductPageComponent implements OnInit {
  product: any;

  constructor(private route: ActivatedRoute, private productService: ProductService) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const productId = params['id']; // ID-ul produsului din URL
      this.productService.getProductById(productId).subscribe(
        (product) => {
          this.product = product; // Produsul este acum stocat în `this.product`
        },
        (error) => {
          console.error('Error fetching product:', error);
        }
      );
    });
  }

}

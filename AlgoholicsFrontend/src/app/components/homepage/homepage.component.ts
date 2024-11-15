import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrl: './homepage.component.css'
})
export class HomepageComponent implements OnInit {

  products: any[] = [];

  constructor (private productService: ProductService) {}

  ngOnInit(): void {
    this.productService.getAllProducts().subscribe(prods => {
      console.log(prods);
    });
  }

}

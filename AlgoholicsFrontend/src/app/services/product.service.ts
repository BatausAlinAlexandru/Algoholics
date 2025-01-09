import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  SERVER_URL = environment.SERVER_URL;
  constructor(private http: HttpClient) { }

  /* returneaza toate produsele din backend */
  getAllProducts(numberOfResults = 10) {
    return this.http.get(this.SERVER_URL+'/products', {
      params: {
        limit: numberOfResults.toString()
      }
    });
  }
  private products = [
    { id: 1, name: 'Produs 1', description: 'Descrierea produsului 1', image: 'imagine1.jpg' },
    { id: 2, name: 'Produs 2', description: 'Descrierea produsului 2', image: 'imagine2.jpg' },
    { id: 3, name: 'Produs 3', description: 'Descrierea produsului 3', image: 'imagine3.jpg' },
  ];

  getProductById(id:number){
    return this.products.find(product => product.id === id);
  }
}

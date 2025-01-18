import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface Product {
  id: string;
  name: string;
  description: string;
  stock: string;
  discount: string;
  price: string;
  idCtegory: string;
}


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private apiUrl = 'https://localhost:32771/api/Product';
  constructor(private http: HttpClient) { }

  public getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.apiUrl}/get`);
  }

  public deleteProduct(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  public updateUser(product: Product): Observable<Product> {
    return this.http.put<Product>(`${this.apiUrl}/update`, product);
  }

}

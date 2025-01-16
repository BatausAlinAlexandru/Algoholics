import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
// import { Product } from './product.model'; // <- adjust path to your actual model file if needed

export interface Product {
  id: string;
  name:string;
  price: number;
  description: string;
  stoc: number;
  discount: number;
  pathFoto: string;
  idCategory: string;
  idSubcategory:string;
  filters: any[];
}

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  /** 
   * Replace with your actual API endpoint.
   * For example: 'https://localhost:7198/api/Product'
   */
  private apiUrl = 'https://localhost:7198/api/Product';

  constructor(private http: HttpClient) {}

  public getAllProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.apiUrl}/get`);
  }

  public getProductById(productId: string): Observable<Product> {
    return this.http.get<Product>(`${this.apiUrl}/get-product/${productId}`);
  }

  // public createProduct(product: Product): Observable<Product> {
  //   return this.http.post<Product>(this.apiUrl, product);
  // }

  // public updateProduct(id: string, product: Product): Observable<Product> {
  //   return this.http.put<Product>(`${this.apiUrl}/${id}`, product);
  // }

  // public deleteProduct(id: string): Observable<void> {
  //   return this.http.delete<void>(`${this.apiUrl}/${id}`);
  // }

}

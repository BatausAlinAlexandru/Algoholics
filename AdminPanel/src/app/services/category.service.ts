import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface Category {
  idCategory: string;
  name: string;
}
export interface Subcategory {
  idSubcategory: string;
  name: string;
  idCategory: string;
}
export interface FilterGroup {
  id: string;
  name: string;
  idSubcategory: string;
}
export interface FilterValue {
  id: string;
  name: string;
  idFilterGroup: string;
}


@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private apiUrl = 'https://localhost:32773/api';

  constructor(private http: HttpClient) { }

  // 1. Obține toate categoriile
  public getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(`${this.apiUrl}/Category/get-all`);
  }

  // 2. Obține toate subcategoriile pe baza unei categorii
  public getSubcategoriesByCategoryId(idCategory: string): Observable<Subcategory[]> {
    return this.http.get<Subcategory[]>(`${this.apiUrl}/Subcategories/get-by-category-id/${idCategory}`);
  }

  // 3. Obține toate grupurile de filtre pe baza unei subcategorii
  public getFilterGroupsBySubcategoryId(idSubcategory: string): Observable<FilterGroup[]> {
    return this.http.get<FilterGroup[]>(`${this.apiUrl}/FilterGroup/get-by-subcategory-id/${idSubcategory}`);
  }

  // 4. Obține toate valorile de filtru pe baza unui grup de filtre
  public getFilterValuesByFilterGroupId(idFilterGroup: string): Observable<FilterValue[]> {
    return this.http.get<FilterValue[]>(`${this.apiUrl}/FilterValue/get-all-by-filter-group-id/${idFilterGroup}`);
  }

  // Metodă pentru adăugarea unei categorii
  addCategory(name: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/Category/add`, { name });
  }

  // Metodă pentru adăugarea unei subcategorii
  addSubcategory(idCategory: string, name: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/Subcategories/add`, { idCategory, name });
  }

  // Metodă pentru adăugarea unui filtruGrup
  addFilterGroup(idSubcategory: string, name: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/FilterGroup/add`, { idSubcategory, name });
  }

  // Metodă pentru adăugarea unui filtruValue
  addFilterValue(idFilterGroup: string, name: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/FilterValue/add`, { idFilterGroup, name });
  }

  deleteCategory(idCategory: string): Observable<any> {
    console.log("ID Categoria trimis:", idCategory);  // Verifică dacă este corect

    const body = { idCategory: idCategory };
    return this.http.delete(`${this.apiUrl}/Category/delete`, { body });

  }

  deleteSubcategory(idSubcategory: string): Observable<any> {
    const body = { idSubcategory: idSubcategory };
    return this.http.delete(`${this.apiUrl}/Subcategories/delete`, { body });
  }

  deleteFilterGroup(idFilterGroup: string): Observable<any> {
    const body = { idFilterGroup: idFilterGroup };
    return this.http.delete(`${this.apiUrl}/FilterGroup/delete`, { body });
  }

  deleteFilterValue(idFilterValue: string): Observable<any> {
    const body = { idFilterValue: idFilterValue };
    return this.http.delete(`${this.apiUrl}/FilterValue/delete`, { body });
  }
}

import { Component, OnInit } from '@angular/core';
import { Category, CategoryService, FilterGroup, FilterValue, Subcategory } from '../../services/category.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  categories: Category[] = [];                // Lista de categorii
  subcategories: Subcategory[] = [];          // Lista de subcategorii
  filterGroups: FilterGroup[] = [];           // Lista de filtre de grupuri
  filterValues: FilterValue[] = [];           // Lista de filtre de valori

  // Variabile pentru elementul selectat
  selectedCategoryId: string = '';            // Id-ul selectat la categorie
  selectedSubcategoryId: string = '';         // Id-ul selectat la subcategorie
  selectedFilterGroupId: string = '';         // Id-ul selectat la filtre de grupuri
  selectedFilterValueId: string = '';         // Id-ul selectat la filtre de valori


  isModalOpen: boolean = false;               // Flag pentru a controla modalul
  newCategoryName: string = '';               // Variabilă pentru numele categoriei
  newSubcategoryName: string = ''             // Variabilă pentru numele subcategoriei
  newFilterGroupName: string = ''             // Variabilă pentru numele filter group
  newFilterValueName: string = ''             // Variabilă pentru numele filter value

  searchTermCategory: string = '';            // Variabilă pentru cautarea categoriilor
  searchTermSubcategory: string = '';         // Variabilă pentru cautarea subcategoriilor
  searchTermFilterGroup: string = '';         // Variabilă pentru cautarea grupurilor de filtre
  searchTermFilterValue: string = '';         // Variabilă pentru cautarea valorilor de filtre

  // Constructor
  constructor(private modalService: NgbModal, private categoryService: CategoryService) { }

  ngOnInit(): void {
    // Încarcă categoriile la inițializare
    this.loadCategories();
  }

  // Încarcă toate categoriile
  loadCategories(): void {
    this.categoryService.getCategories().subscribe(data => {
      this.categories = data;
    });
  }

  // Încarcă toate subcategoriile
  loadSubcategories(idCategory: string): void {
    this.categoryService.getSubcategoriesByCategoryId(idCategory).subscribe(data => {
      this.subcategories = data;
    });
  }

  // Încarcă toate filtrele de grupuri
  loadFilterGroup(idSubcategory: string): void {
    if (this.filterGroups.length === 0) {
      // Dacă lista de FilterValues este goală, nu trimite cererea
      console.log('Nu există FilterGroups de încărcat');
      return;
    }

    this.categoryService.getFilterGroupsBySubcategoryId(idSubcategory).subscribe(data => {
      this.filterGroups = data;
    });
  }

  // Încarcă toate filtrele de valori
  loadFilterValue(idFilterGroup: string): void {
    this.categoryService.getFilterValuesByFilterGroupId(idFilterGroup).subscribe(data => {
      this.filterValues = data;
    });
  }

  // Când selectezi o categorie
  selectCategory(idCategory: string): void {
    this.selectedCategoryId = idCategory;
    // Obținem subcategoriile pe baza categoriei selectate
    this.categoryService.getSubcategoriesByCategoryId(idCategory).subscribe({
      next: (subcategories: Subcategory[]) => {
        this.subcategories = subcategories;

        // Resetăm nivelurile inferioare
        this.filterGroups = [];
        this.filterValues = [];
        this.selectedSubcategoryId = '';
        this.selectedFilterGroupId = '';
        this.selectedFilterValueId = '';
      },
      error: (err) => {
        console.error('Eroare la obținerea subcategoriilor:', err);
        // Dacă apare o eroare, curățăm datele
        this.subcategories = [];
        this.filterGroups = [];
        this.filterValues = [];
        this.selectedSubcategoryId = '';
        this.selectedFilterGroupId = '';
        this.selectedFilterValueId = '';
      }
    });
  }

  // Când selectezi o subcategorie
  selectSubcategory(idSubcategory: string): void {
    this.selectedSubcategoryId = idSubcategory;

    // Obținem grupurile de filtre pentru subcategoria selectată
    this.categoryService.getFilterGroupsBySubcategoryId(idSubcategory).subscribe({
      next: (filterGroups: FilterGroup[]) => {
        this.filterGroups = filterGroups;

        // Resetăm valorile filtrului
        this.filterValues = [];
        this.selectedFilterGroupId = '';
        this.selectedFilterValueId = '';
      },
      error: (err) => {
        console.error('Eroare la obținerea grupurilor de filtre:', err);
        // Dacă apare o eroare, curățăm datele
        this.filterGroups = [];
        this.filterValues = [];
        this.selectedFilterGroupId = '';
        this.selectedFilterValueId = '';
      }
    });
  }

  // Când selectezi un grup de filtre
  selectFilterGroup(id: string): void {
    this.selectedFilterGroupId = id;

    // Obținem valorile filtrului
    this.categoryService.getFilterValuesByFilterGroupId(id).subscribe({
      next: (filterValues: FilterValue[]) => {
        this.filterValues = filterValues;
        this.selectedFilterValueId = '';
      },
      error: (err) => {
        console.error('Eroare la obținerea valorilor de filtru:', err);
        // Dacă apare o eroare, curățăm datele
        this.filterValues = [];
        this.selectedFilterValueId = '';
      }
    });
  }

  // Când selectezi o valoare de filtru
  selectFilterValue(id: string): void {
    this.selectedFilterValueId = id;
  }

  // Funcție pentru deschiderea modalului
  openModal(modal: any): void {
    this.modalService.open(modal);
  }

  // Funcție pentru salvarea categoriei
  saveCategory(modal: any): void {
    if (this.newCategoryName.trim() === '') {
      alert('Introduceți un nume valid pentru categorie!');
      return;
    }
    this.categoryService.addCategory(this.newCategoryName).subscribe({
      next: () => {
        modal.close(); // Închide modalul
        this.newCategoryName = ''; // Resetează câmpul
        this.loadCategories();
      },
      error: (err) => {
        console.error(err);
        alert('Eroare la adăugarea categoriei.');
      }
    });
   
  }

  // Funcție pentru salvarea subcategoriei
  saveSubcategory(modal: any): void {
    if (this.newSubcategoryName.trim() === '') {
      alert('Introduceți un nume valid pentru subcategorie!');
      return;
    }
    this.categoryService.addSubcategory(this.selectedCategoryId, this.newSubcategoryName).subscribe({
      next: () => {
        modal.close(); // Închide modalul
        this.newSubcategoryName = ''; // Resetează câmpul
        this.loadSubcategories(this.selectedCategoryId);
      },
      error: (err) => {
        console.error(err);
        alert('Eroare la adăugarea subcategoriei.');
      }
    });
  }

  // Funcție pentru salvarea filterGroup
  saveFilterGroup(modal: any): void {
    if (this.newFilterGroupName.trim() === '') {
      alert('Introduceți un nume valid pentru filtru gurp!');
      return;
    }
    this.categoryService.addFilterGroup(this.selectedSubcategoryId, this.newFilterGroupName).subscribe({
      next: () => {
        modal.close(); // Închide modalul
        this.newFilterGroupName = ''; // Resetează câmpul
        this.loadFilterGroup(this.selectedSubcategoryId);
      },
      error: (err) => {
        console.error(err);
        alert('Eroare la adăugarea filterGroup.');
      }
    });
  }

  // Funcție pentru salvarea filterValue
  saveFilterValue(modal: any): void {
    if (this.newFilterValueName.trim() === '') {
      alert('Introduceți un nume valid pentru filtru value!');
      return;
    }
    this.categoryService.addFilterValue(this.selectedFilterGroupId, this.newFilterValueName).subscribe({
      next: () => {
        modal.close(); // Închide modalul
        this.newFilterValueName = ''; // Resetează câmpul
        this.loadFilterValue(this.selectedFilterGroupId);
      },
      error: (err) => {
        console.error(err);
        alert('Eroare la adăugarea filterGroup.');
      }
    });
  }

  // Metoda care apelează `deleteCategory`
  deleteCategory(idCategory: string): void {
    this.categoryService.deleteCategory(idCategory).subscribe({
      next: (response) => {
        console.log('Categorie ștearsă cu succes!', response);
        this.loadCategories();
      },
      error: (error) => {
        console.error('Eroare la ștergerea categoriei', error);
      }
    });
  }

  // Metoda care apelează `deleteSubcategory`
  deleteSubcategory(idSubcategory: string): void {
    this.categoryService.deleteSubcategory(idSubcategory).subscribe({
      next: (response) => {
        console.log('Subcategorie ștearsă cu succes!', response);
        this.loadSubcategories(this.selectedCategoryId);
      },
      error: (error) => {
        console.error('Eroare la ștergerea subcategoriei', error);
      }
    });
  }

  // Metoda care apelează `deleteFilterGroup`
  deleteFilterGroup(idFilterGroup: string): void {
    this.categoryService.deleteFilterGroup(idFilterGroup).subscribe({
      next: (response) => {
        console.log('Grupul de filtre ștearsă cu succes!', response);
        this.loadFilterGroup(this.selectedSubcategoryId);
      },
      error: (error) => {
        console.error('Eroare la ștergerea grupului de filtre', error);
      }
    });
  }

  // Metoda care apelează `deleteFilterValue`
  deleteFilterValue(idFilterValue: string): void {
    this.categoryService.deleteFilterValue(idFilterValue).subscribe({
      next: (response) => {
        console.log('Valoarea filtrului ștearsă cu succes!', response);
        this.loadFilterValue(this.selectedFilterGroupId);
      },
      error: (error) => {
        console.error('Eroare la ștergerea valorii filtrului', error);
      }
    });
  }

  get filteredCategory() {
    if (!this.searchTermCategory) {
      return this.categories;
    }

    const lowerCaseSearchTerm = this.searchTermCategory.toLowerCase();
    return this.categories.filter(category =>
      category.name.toLowerCase().includes(lowerCaseSearchTerm)
    );
  }
  get filteredSubcategory() {
    if (!this.searchTermSubcategory) {
      return this.subcategories;
    }

    const lowerCaseSearchTerm = this.searchTermSubcategory.toLowerCase();
    return this.subcategories.filter(subcategory =>
      subcategory.name.toLowerCase().includes(lowerCaseSearchTerm)
    );
  }

  get filteredFilterGroup() {
    if (!this.searchTermFilterGroup) {
      return this.filterGroups;
    }

    const lowerCaseSearchTerm = this.searchTermFilterGroup.toLowerCase();
    return this.filterGroups.filter(filterGroup =>
      filterGroup.name.toLowerCase().includes(lowerCaseSearchTerm)
    );
  }

  get filteredFilterValue() {
    if (!this.searchTermFilterValue) {
      return this.filterValues;
    }

    const lowerCaseSearchTerm = this.searchTermFilterValue.toLowerCase();
    return this.filterValues.filter(filterValue =>
      filterValue.name.toLowerCase().includes(lowerCaseSearchTerm)
    );
  }
}

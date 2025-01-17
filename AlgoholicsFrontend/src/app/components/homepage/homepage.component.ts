import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { CartService } from '../../services/cart.service';
import { WishlistService } from '../../services/wishlist.service';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {
  
  products: any[] = [];
  categories: any[] = [];
  filteredProducts: any[] = [];
  selectedCategory: string = ''; // Categorie selectată pentru filtrare
  loggedInUserId: string = '';

  // 1) States for tracking the wishlist icon and success animation
  isWishlistActive: { [productId: number]: boolean } = {};
  showWishlistSuccess: { [productId: number]: boolean } = {};
  isCartActive: { [productId: number]: boolean } = {};
  showCartSuccess: { [productId: number]: boolean } = {};
  isAuthenticated: boolean = false; 

  constructor(
    private productService: ProductService,
    private cartService: CartService,
    private wishlistService: WishlistService,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit(): void {
    // Preluăm mai întâi categoriile
    this.productService.getAllCategories().subscribe(
      (categories: any[]) => {
        this.categories = categories;
        // După ce avem categoriile, preluăm produsele
        this.productService.getAllProducts().subscribe(
          (products: any[]) => {
            this.products = products;

            // Asociem numele categoriei fiecărui produs, folosind categoriile deja disponibile
            this.products = this.products.map(product => ({
              ...product,
              categoryName: this.getCategoryNameById(product.idCtegory)
            }));

            // La început, toate produsele sunt vizibile
            this.filteredProducts = this.products;

            // Setează butonul "All Products" ca activ
            this.setActiveCategoryButton('All');
          },
          (error) => console.error('Error fetching products:', error)
        );
      },
      (error) => console.error('Error fetching categories:', error)
    );
    this.isAuthenticated = this.authService.isAuthenticated();
    this.loggedInUserId = this.authService.getUserIdFromToken();
  }

  getCategoryNameById(idCtegory: number): string {
    const category = this.categories.find(cat => cat.idCategory === idCtegory);
    return category ? category.name : 'Category unknown';
  }


  // Modifică funcția de filtrare pentru a gestiona activarea butonului selectat
  filterProducts(category: string): void {
    this.selectedCategory = category; // Setează categoria selectată

    if (category === 'All') {
      this.filteredProducts = this.products; // Dacă se selectează "All", toate produsele sunt vizibile
    } else {
      this.filteredProducts = this.products.filter(product => product.categoryName === category); // Filtrează produsele după categoria aleasă
    }

    // Schimbă clasa activă pe butonul selectat
    this.setActiveCategoryButton(category);
  }

  // Funcția de setare a butonului activ
  setActiveCategoryButton(category: string): void {
    const tabs = document.querySelectorAll('.section-tab-nav li');
    tabs.forEach(tab => {
      tab.classList.remove('active'); // Îndepărtează clasa 'active' de la toate
    });

    // Adaugă clasa 'active' pe butonul corespunzător
    const activeTab = Array.from(tabs).find((tab: any) => {
      return tab.textContent.trim() === category;
    });
    if (activeTab) {
      activeTab.classList.add('active');
    }
  }

  redirectToLogin(): void {
    this.router.navigate(['/login']);
  }

  addToCart(product: any): void {
    this.isCartActive[product.id] = true;
  
    // Build the CartItem properly:
    const cartItem = {
      productId: product.id,      // or product.productId if that's the actual property
      quantity: product.quantity || 1  // If product doesn't have a quantity, default to 1
    };
  
    this.cartService.addProductToCart(this.loggedInUserId, cartItem).subscribe(
      (updatedCart) => {
        console.log('Product added to cart', updatedCart);
        this.cartService.fetchCartCount(this.loggedInUserId);
  
        // Trigger the checkmark animation
        this.showCartSuccess[product.id] = true;
  
        // Hide the checkmark after 1 second (adjust time as you wish)
        setTimeout(() => {
          this.showCartSuccess[product.id] = false;
        }, 1100);
      },
      (error) => {
        console.error('Error adding to cart', error);
        // If there was an error, revert the fill
        this.isCartActive[product.id] = false;
      }
    );
  }

  addToWishlist(product: any): void {
    this.isWishlistActive[product.id] = true;

    this.wishlistService.addProductToWishlist(this.loggedInUserId, product.id).subscribe(
      (updatedWishlist) => {
        console.log('Product added to wishlist', updatedWishlist);
        this.wishlistService.fetchWishlistCount(this.loggedInUserId);


        // Trigger the checkmark animation
        this.showWishlistSuccess[product.id] = true;

        // Hide the checkmark after 1 second (adjust time as you wish)
        setTimeout(() => {
          this.showWishlistSuccess[product.id] = false;
        }, 1100);
      },
      (error) => {
        console.error('Error adding to wishlist', error);
        // If there was an error, revert the fill
        this.isWishlistActive[product.id] = false;
      }
    );
  }

  viewProduct(id: number): void {
    this.router.navigate(['/product-details', id]);
  }
}


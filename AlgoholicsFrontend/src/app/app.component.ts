import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'] 
})
export class AppComponent {
  title = 'Project1';

  constructor(private router: Router) { }

  // Funcție care verifică dacă ruta curentă este login sau signup
  showNavbar(): boolean {
    return !['/login', '/signup'].includes(this.router.url); // Ascunde header-ul pe login și signup
  }

  // Funcție care verifică dacă ruta curentă este login sau signup
  showFooter(): boolean {
    return !['/login', '/signup'].includes(this.router.url); // Ascunde footer-ul pe login și signup
  }

}

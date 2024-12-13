import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'] 
})
export class AppComponent implements OnInit {
  title = 'Project1';

  constructor(private router: Router) { }

  ngOnInit() {
    // Load theme from localStorage
    const root = document.documentElement;
    const savedTheme = localStorage.getItem('theme') || 'light';

    if (savedTheme === 'dark') {
      root.classList.add('dark-mode');
    }

    const themeToggle = document.getElementById('theme-toggle') as HTMLElement;
    themeToggle.textContent = savedTheme === 'dark' ? 'Light Mode' : 'Dark Mode';

    // Toggle theme
    themeToggle.addEventListener('click', () => {
      const isDarkMode = root.classList.toggle('dark-mode');
      localStorage.setItem('theme', isDarkMode ? 'dark' : 'light');
      themeToggle.textContent = isDarkMode ? 'Light Mode' : 'Dark Mode';
    });
  }

  // Funcție care verifică dacă ruta curentă este login sau signup
  showNavbar(): boolean {
    return !['/login', '/signup'].includes(this.router.url); // Ascunde header-ul pe login și signup
  }

  // Funcție care verifică dacă ruta curentă este login sau signup
  showFooter(): boolean {
    return !['/login', '/signup'].includes(this.router.url); // Ascunde footer-ul pe login și signup
  }

}


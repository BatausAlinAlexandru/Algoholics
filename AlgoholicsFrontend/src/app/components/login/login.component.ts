import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  email = '';
  password = '';

  constructor(private authService: AuthService, private router: Router) { }

  onLogin() {
    if (this.authService.login(this.email, this.password)) {

      alert('Login successful!');
      this.router.navigate(['/']);
    } else {

      alert('Invalid credentials...');
    }
  }

  redirectToSignUp() {
    this.router.navigate(['/signup']);
  }
}

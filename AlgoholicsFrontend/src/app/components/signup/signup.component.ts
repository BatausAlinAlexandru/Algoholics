import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.css'
})
export class SignupComponent {
  email = '';
  username = '';
  password = '';

  constructor(private authService: AuthService, private router: Router) { }

  onSignup() {
    if (this.authService.signup(this.email, this.username, this.password)) {
      alert('Sign up successful');
      this.router.navigate(['/']);
    } else {
      alert('Email already in use');
    }
  }

  redirectToLogIn() {
    this.router.navigate(['/login']);
  }
}

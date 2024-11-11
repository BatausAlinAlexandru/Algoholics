import { Component } from '@angular/core';
import { AuthService } from '../auth/auth.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-signup',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.css'
})
export class SignupComponent {
  email = '';
  username = '';
  password = '';

  constructor( private authService: AuthService, private router: Router){}

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

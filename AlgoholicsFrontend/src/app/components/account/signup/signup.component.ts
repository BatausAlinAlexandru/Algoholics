import { Component } from '@angular/core';
import { AuthService } from '../../../services/auth.service';
import { Router, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';

@Component({
  selector: 'app-signup',
  //standalone: true,
  imports: [FormsModule, RouterModule],
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

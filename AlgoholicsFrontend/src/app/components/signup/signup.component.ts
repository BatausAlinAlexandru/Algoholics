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
  password = '';
  errorMessage = '';

  constructor(private authService: AuthService, private router: Router) { }

  onSignup() {
    this.authService.signup(this.email, this.password).subscribe(
      () => {
        alert('Sign up successful!');
        this.router.navigate(['/login']); // Redirecționează către login după înregistrare
      },
      (error) => {
        this.errorMessage = error.error?.message || 'Failed to sign up. Please try again.';
      }
    );
  }

  redirectToLogIn() {
    this.router.navigate(['/login']);
  }
}

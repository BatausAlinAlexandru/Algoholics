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
  errorMessage = '';

  constructor(private authService: AuthService, private router: Router) { }

  onLogin() {
      this.authService.login(this.email, this.password).subscribe(
        (response: any) => {
          const token = response.token;
          localStorage.setItem('token', token);
        },
        (error) => {
          this.errorMessage = 'Invalid email or password';
        }
      );
  }

  redirectToSignUp() {
    this.router.navigate(['/signup']);
  }
}

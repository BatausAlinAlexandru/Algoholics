import { Component } from '@angular/core';
import { AuthService } from '../../../services/auth.service';
import { Router, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';

@Component({
  selector: 'app-login',
  //standalone: true,
  imports: [FormsModule, RouterModule],
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

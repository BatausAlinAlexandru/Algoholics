import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { jwtDecode } from "jwt-decode";


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  email: string = '';
  password: string = '';
  errorMessage: string = '';

  constructor(private authService: AuthService, private router: Router) { }

  onSubmit() {
    this.authService.login(this.email, this.password).subscribe(
      (response: any) => {
        const token = response.token;
        localStorage.setItem('token', token);

        const decodedToken: any = jwtDecode(token);

        if (decodedToken.role && decodedToken.role === 'Admin') {
          this.router.navigate(['']);
        } else {
          this.errorMessage = 'You do not have admin privileges';
        }
      },
      (error) => {
        this.errorMessage = 'Invalid email or password';
      }
    );
  }

}

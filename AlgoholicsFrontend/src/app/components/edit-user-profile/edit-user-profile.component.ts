import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-edit-user-profile',
  templateUrl: './edit-user-profile.component.html',
  styleUrl: './edit-user-profile.component.css'
})
export class EditUserProfileComponent {

  constructor(private authService: AuthService, private router: Router) { }

  redirectToEditProfile() {
    this.router.navigate(['/edit-user-profile']);
  }
}

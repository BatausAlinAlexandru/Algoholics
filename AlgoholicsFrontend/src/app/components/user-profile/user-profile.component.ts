import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrl: './user-profile.component.css'
})
export class UserProfileComponent implements OnInit {

  users: any[] = [];
  loggedInUserId: string = '';

  constructor(
    private userService: UserService,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.userService.getAllUsers().subscribe(
      (users: any[]) => {
        this.users = users;
    })

    this.users = this.users.map(user => ({
      ...user,
    }));

    this.loggedInUserId = this.authService.getUserIdFromToken();
    
  }

  get filteredUsers() {
    return this.users.filter(user => user.id === this.loggedInUserId);
  }

  redirectToProfile() {
    this.router.navigate(['/user-profile']);
  }

  logOut() {
    this.authService.logOut();
  }

}


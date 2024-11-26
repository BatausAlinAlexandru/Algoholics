import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private users: { email: string; username: string; password: string }[] = [];

  login(email: string, password: string): boolean {
    const user = this.users.find(user => user.email === email &&
      user.password === password)

    return !!user;
  }

  signup(email: string, username: string, password: string): boolean {
    const existingUser = this.users.find(user => user.email === email);
    if (existingUser) return false;

    this.users.push({ email, username, password });
    return true;
  }



  //  constructor() { }
}

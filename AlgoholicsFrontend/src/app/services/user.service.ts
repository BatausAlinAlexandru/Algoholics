import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface User {
  id: string;
  email: string;
  userAccountRole: string;
  dateCreated: string;
  userAccountGender: string;
  alias: string;
}

@Injectable({
  providedIn: 'root'
})

export class UserService {
  private apiUrl = 'https://localhost:7198/api/UserAccount';
  constructor(private http: HttpClient) { }

  public getAllUsers(): Observable<User[]> {
    return this.http.get<User[]>(`${this.apiUrl}/get-users`);
  }

  public getUserById(userId: string): Observable<User> {
    return this.http.get<User>(`${this.apiUrl}/get-user${userId}`);
  }

  public updateUser(user: User): Observable<any> {
    const url = `${this.apiUrl}/update-user-account-admin-panel`;
    return this.http.put(url, user);
  }
}
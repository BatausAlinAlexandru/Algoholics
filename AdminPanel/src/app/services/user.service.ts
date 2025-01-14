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
  private apiUrl = 'https://localhost:32773/api/UserAccount';

  constructor(private http: HttpClient) { }

  public getUsers(): Observable<User[]> {
    return this.http.get<User[]>(`${this.apiUrl}/get-users`);
  }

  public deleteUser(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  public updateUser(user: User): Observable<User> {
    return this.http.put<User>(`${this.apiUrl}/update-user-account-admin-panel`, user);
  }
}

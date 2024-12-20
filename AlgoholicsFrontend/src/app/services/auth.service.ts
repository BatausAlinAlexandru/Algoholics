import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiUrl = 'https://localhost:7198/api/Authentication';
  private signupApiUrl = 'https://localhost:7198/api/UserAccount';
  private authenticated = new BehaviorSubject<boolean>(false);
  public isAuthenticated$ = this.authenticated.asObservable();

  constructor(private http: HttpClient, private router: Router) {
    const token = localStorage.getItem('token');
    this.authenticated.next(!!token);
  }

  public login(email: string, password: string): Observable<any> {
    return this.http.post(`${this.apiUrl}`, { email, password }).pipe(
      tap((response: any) => {
        const token = response.token;
        if (token) {
          localStorage.setItem('token', token);
          this.authenticated.next(true);


          this.router.navigate(['']).then(() => {
            window.location.reload();
          });

        }
      })
    );
  }

  signup(email: string, password: string): Observable<any> {
    return this.http.post(`${this.signupApiUrl}`, { email, password });
  }

  logout() {
    localStorage.removeItem('token');
    this.authenticated.next(false);
    this.router.navigate(['/login']);
  }
}

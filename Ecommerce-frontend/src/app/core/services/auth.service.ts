import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LoginModel } from '../models/LoginModel';
import { RegisterModel } from '../models/RegisterModel';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'http://localhost:12889/api/auth';

  constructor(private http: HttpClient) { }

  login(credentials: LoginModel): Observable<any> {
    return this.http.post(`${this.apiUrl}/login`, credentials);
  }

  register(user: RegisterModel): Observable<any> {
    return this.http.post(`${this.apiUrl}/register`, user);
  }

  logout(): Observable<any> {
    this.removeToken();  // Remover o token ao deslogar
    return this.http.post(`${this.apiUrl}/logout`, {});
  }

  // Métodos para manipular o token
  setToken(token: string): void {
    localStorage.setItem('jwt', token);
  }

  getToken(): string | null {
    return localStorage.getItem('jwt');
  }

  removeToken(): void {
    localStorage.removeItem('jwt');
  }
}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CartItemDto } from '../dtos/cart-item.dto'; // Ajuste o caminho conforme necessário

@Injectable({
  providedIn: 'root'
})
export class CartService {
  private apiUrl = 'http://localhost:5000/api/cart'; // Ajuste a URL conforme necessário

  constructor(private http: HttpClient) { }

  getCartItems(): Observable<CartItemDto[]> {
    return this.http.get<CartItemDto[]>(this.apiUrl);
  }

  removeItem(itemId: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${itemId}`);
  }
}

import { Component, OnInit } from '@angular/core';
import { CartItemDto } from '../../../../core/dtos/cart-item.dto';
import { CartService } from '../../../../core/services/cart.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  cartItems: CartItemDto[] = [];
  totalAmount: number = 0;

  constructor(private cartService: CartService) { }

  ngOnInit(): void {
    this.loadCartItems();
  }

  loadCartItems(): void {
    this.cartService.getCartItems().subscribe(items => {
      this.cartItems = items;
      this.calculateTotal();
    });
  }

  calculateTotal(): void {
    this.totalAmount = this.cartItems.reduce((total, item) => total + item.price * item.quantity, 0);
  }

  removeItem(itemId: number): void {
    this.cartService.removeItem(itemId).subscribe(() => {
      this.loadCartItems();
    });
  }
}

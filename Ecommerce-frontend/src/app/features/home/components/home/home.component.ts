import { Component, OnInit, Renderer2 } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  constructor(private renderer: Renderer2) { }
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

  addToCart(product: any) {
    console.log('Product added to cart:', product);
  }
}

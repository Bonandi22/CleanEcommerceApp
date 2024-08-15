import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CartComponent } from './components/cart/cart.component';
import { MatTableModule } from '@angular/material/table'; // Import MatTableModule

@NgModule({
  declarations: [
    CartComponent
  ],
  imports: [
    CommonModule,
    MatTableModule, // Add MatTableModule to imports
    RouterModule.forChild([
      { path: '', component: CartComponent }
    ])
  ]
})
export class CartModule { }

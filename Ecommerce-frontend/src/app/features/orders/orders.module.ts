import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { OrdersComponent } from './components/orders/orders.component';

@NgModule({
  declarations: [
    OrdersComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: '', component: OrdersComponent }
    ])
  ]
})
export class OrdersModule { }

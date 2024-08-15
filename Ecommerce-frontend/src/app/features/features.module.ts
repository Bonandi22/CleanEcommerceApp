import { NgModule } from '@angular/core';
import { HomeModule } from './home/home.module';
import { AuthModule } from './auth/auth.module';
import { ProductsModule } from './products/products.module';
import { CartModule } from './cart/cart.module';
import { OrdersModule } from './orders/orders.module';

@NgModule({
  imports: [
    HomeModule,
    AuthModule,
    ProductsModule,
    CartModule,
    OrdersModule,
  ],
})
export class FeaturesModule { }

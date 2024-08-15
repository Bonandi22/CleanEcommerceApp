import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  // Rota para o módulo Home
  { path: '', loadChildren: () => import('./features/home/home.module').then(m => m.HomeModule) },

  // Rota para o módulo Auth (login e register)
  { path: 'auth', loadChildren: () => import('./features/auth/auth.module').then(m => m.AuthModule) },

  // Rota para o módulo Products
  { path: 'products', loadChildren: () => import('./features/products/products.module').then(m => m.ProductsModule) },

  // Rota para o módulo Cart
  { path: 'cart', loadChildren: () => import('./features/cart/cart.module').then(m => m.CartModule) },

  // Rota para o módulo Orders
  { path: 'orders', loadChildren: () => import('./features/orders/orders.module').then(m => m.OrdersModule) },

  // Rota coringa para páginas não encontradas
  { path: '**', redirectTo: '', pathMatch: 'full' } // Redireciona para Home se a rota não for encontrada
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

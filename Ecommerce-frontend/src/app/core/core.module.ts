import { NgModule, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { AuthService } from './services/auth.service';
import { UserService } from './services/user.service';
import { ProductService } from './services/product.service';

// CoreModule é usado para fornecer serviços singleton
@NgModule({
  imports: [
    CommonModule, // Importa as diretivas e pipes comuns do Angular
    HttpClientModule // Importa o módulo HTTP para serviços de comunicação com API
  ],
  providers: [
    AuthService, // Serviço de autenticação
    UserService, // Serviço para manipulação de usuários
    ProductService // Serviço para manipulação de produtos
  ]
})
export class CoreModule {
  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
    if (parentModule) {
      throw new Error(
        'CoreModule is already loaded. Import it in the AppModule only.');
    }
  }
}

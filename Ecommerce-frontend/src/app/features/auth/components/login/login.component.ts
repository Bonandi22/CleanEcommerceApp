import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../../../core/services/auth.service';
import { LoginModel } from '../../../../core/models/LoginModel';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm: FormGroup;

  constructor(private fb: FormBuilder, private authService: AuthService, private router: Router) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });
  }

  onSubmit(): void {
    if (this.loginForm.valid) {
      const credentials: LoginModel = this.loginForm.value;
      this.authService.login(credentials).subscribe(
        response => {
          console.log('Login successful', response);
          if (response.token) {
            this.authService.setToken(response.token);  // Armazena o token
          }
          this.router.navigate(['/home']);
        },
        error => {
          console.error('Login error', error);
        }
      );
    }
  }
}

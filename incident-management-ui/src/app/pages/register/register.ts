import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { ReactiveFormsModule, FormBuilder, Validators, FormGroup } from '@angular/forms';
import { Auth } from '../../services/auth';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [RouterLink, ReactiveFormsModule,CommonModule],
  templateUrl: './register.html',
  styleUrl: './register.css'
})
export class Register{

  showPassword = false;
  registerForm!: FormGroup;

  constructor(private fb: FormBuilder,private authService: Auth) {
    this.registerForm = this.fb.group({
      username: ['', [Validators.required, Validators.minLength(3)]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  togglePassword(){
    this.showPassword = !this.showPassword;
  }

onSubmit() {
  if(this.registerForm.valid){
    this.authService.register(this.registerForm.value).subscribe({
      next: (res) => {
        console.log('User registered', res);
        alert("Registration successful");
      },
      error: (err) => {
        console.error(err);
        alert("Registration failed");
      }
    });
  }
}

}
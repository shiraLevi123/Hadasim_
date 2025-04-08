import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { SupplierService } from '../../../services/supplier.service';
import { CommonModule } from '@angular/common';

@Component({
  standalone: true,
  selector: 'app-login',
  imports: [ReactiveFormsModule, CommonModule,RouterModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {
  public loginForm!: FormGroup;
  error: boolean = false;
  wrongName: boolean = false;

  constructor(private router: Router, private _supplierService: SupplierService) {
  }

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      'companyName': new FormControl('', Validators.required),
      'password': new FormControl('', Validators.required)
    })
  }

  login() {
    const { companyName, password } = this.loginForm.value;
    this._supplierService.login(companyName, password).subscribe({
      next: (supplier) => {
        localStorage.setItem('supplierId', supplier.id.toString());
        this.router.navigate(['/order']);
      },
      error: (err) => {
        if (err.status === 401) {
          this.wrongName = true;
        }

      }
    });

  }
}
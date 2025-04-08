import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { SupplierService } from '../../../services/supplier.service';

@Component({
  standalone: true,
  selector: 'app-register',
  imports: [ReactiveFormsModule, CommonModule, RouterModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent implements OnInit {
  registerForm!: FormGroup;
  error: boolean = false;

  constructor(private fb: FormBuilder, private _supplierService: SupplierService, private router: Router) {

  }
  ngOnInit(): void {
    this.registerForm = this.fb.group({
      companyName: ['', Validators.required],
      phone: ['', Validators.required],
      agentName: ['', Validators.required],
      password: ['', Validators.required],
      products: this.fb.array([
        this.createProductGroup()
      ])
    });
  }

  get products(): FormArray {

    return this.registerForm.get('products') as FormArray;
  }

  createProductGroup(): FormGroup {
    return this.fb.group({
      productName: ['', Validators.required],
      pricePerUnit: [0, [Validators.required, Validators.min(0)]], 
      minQuantity: [1, [Validators.required, Validators.min(1)]],
    });
  }

  addProduct(): void {

    this.products.push(this.createProductGroup());
  }

  register(): void {
    if (this.registerForm.invalid) return;
    console.log('נתונים שנשלחים: ', this.registerForm.value);
    this._supplierService.register(this.registerForm.value).subscribe({
      next: res => {
        console.log('ספק נרשם', res);
      },
      error: err => {
        console.error('שגיאה בהרשמה', err);
      }
    });
  }
  

}
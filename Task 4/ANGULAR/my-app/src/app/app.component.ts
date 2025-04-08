import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Router, RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [CommonModule, RouterLink, RouterOutlet], // כולל שניהם
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'my-app';

  constructor( private router: Router) { 

  }
  isLoggedIn(): boolean {
    return !!localStorage.getItem('supplierId');
  }

  logout(): void {
    localStorage.removeItem('supplierId');
    this.router.navigate(['/login']);
}
}
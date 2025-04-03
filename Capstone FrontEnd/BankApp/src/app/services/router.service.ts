import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class RouterService {

  constructor(private router:Router) { }

  navigateToLogin() {
    this.router.navigate(['login']);
  }
  navigateToDashBoard() {
    this.router.navigate(['dashboard']);
  }
  navigateToRegister(){
    this.router.navigate(['register']);

  }
}

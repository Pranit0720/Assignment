import { Component, OnDestroy, OnInit } from '@angular/core';
import { RouterService } from '../../services/router.service';
import { Route, Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterModule,CommonModule,FormsModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {
  constructor(public userservice: UserService,private router:Router) {}
 
 
  logout() {
    localStorage.clear();
    this.router.navigate(['/login']);
  }
}
  


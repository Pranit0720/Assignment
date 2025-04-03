import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { RouterService } from '../../services/router.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-dash-board',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './dash-board.component.html',
  styleUrl: './dash-board.component.css'
})
export class DashBoardComponent {
  title = 'Welcome to Our Online Banking Platform';
  subtitle = 'Secure, Fast, and Reliable Banking Services';
  services = [
    { name: 'Account Overview', description: 'Check your balance and recent transactions' },
    { name: 'Fund Transfers', description: 'Send money securely and instantly' },
    { name: 'Bill Payments', description: 'Pay your utility bills with ease' }
    // { name: 'Loan Services', description: 'Apply for and manage your loans online' }
  ];
}


import { Component } from '@angular/core';
import { Accounts, AccountTypes, AddAccount } from '../../model/accounts';
import { AccountService } from '../../services/account.service';
import { Router, RouterModule } from '@angular/router';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-add-account',
  standalone: true,
  imports: [CommonModule,FormsModule,RouterModule],
  templateUrl: './add-account.component.html',
  styleUrl: './add-account.component.css'
})
export class AddAccountComponent {
  newAccount: AddAccount = {
    accountNumber: 0,
    balance: 0,
    accountTypes: AccountTypes.Saving_Account // ✅ Set default as an enum value
    
  };
 
  successMessage = '';
  errorMessage = '';
 
  constructor(private accountsService: AccountService,private router:Router) {}
 
  addAccount(form: NgForm) {
    if (form.invalid) {
      this.errorMessage = 'Please fill in all required fields';
      return;
    }
 
    this.accountsService.AddAccount(this.newAccount).subscribe({
      next: (response) => {
        alert( 'Account added successfully!');
        this.router.navigate(['myAccounts']);
          
        form.reset();
      },
      error: (error) => {
        this.errorMessage = 'Failed to add account.';
        console.error(error);
      }
    });
  }

  

  

}

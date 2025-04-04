import { Component, EventEmitter, Output } from '@angular/core';
import { Accounts, AccountTypes, AddAccount } from '../../model/accounts';
import { AccountService } from '../../services/account.service';
import { Router, RouterModule } from '@angular/router';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AccountEnumString } from '../../constants';

@Component({
  selector: 'app-add-account',
  standalone: true,
  imports: [CommonModule,FormsModule,RouterModule],
  templateUrl: './add-account.component.html',
  styleUrl: './add-account.component.css'
})
export class AddAccountComponent {
  

  // newAccount: AddAccount = {
  //   accountNumber: 0,
  //   balance: 0,
  //   accountTypes: AccountTypes.Current_Account // ✅ Set default as an enum value
  // };
 
  // successMessage = '';
  // errorMessage = '';
 
  // constructor(private accountsService: AccountService,private router:Router) {}
 
  // addAccount(form: NgForm) {
  //   if (form.invalid) {
  //     this.errorMessage = 'Please fill in all required fields';
  //     return;
  //   }
 
  //   this.accountsService.AddAccount(this.newAccount).subscribe({
  //     next: (response) => {
  //       // this.successMessage = 'Account added successfully!';
  //       alert( 'Account added successfully!');
  //       this.router.navigate(['/accounts'])
  //         this.errorMessage = '';
  //       form.resetForm();
  //     },
  //     error: (error) => {
  //       this.errorMessage = 'Failed to add account.';
  //       console.error(error);
  //     }
  //   });
  // }



  @Output() accountAdded = new EventEmitter<any>();
 
  newAccount: {
 
    accountNumber: number | null;
    balance: number | null;
    accountTypes: number | null;
  } = {
    accountNumber: null,
    balance: null,
    accountTypes: null
  };
 
  constructor(private accountService: AccountService,private router:Router) {}
 
  addAccount() {
    // Ensure accountTypes is a number
    this.newAccount.accountTypes = Number(this.newAccount.accountTypes);
 
    this.accountService.AddAccount(this.newAccount).subscribe(
      (response) => {
        console.log('Account added successfully', response);
        alert('Account added successfully!');
        this.accountAdded.emit(response); // Notify parent component
        this.resetForm();
        this.router.navigate(['myAccounts'])
      },
      (error) => {
        console.error('Error adding account', error);
        alert('Failed to add account. Please try again.');
      }
    );
  }
 
  resetForm() {
    this.newAccount = {accountNumber: null, balance: null, accountTypes: null };
  }

}

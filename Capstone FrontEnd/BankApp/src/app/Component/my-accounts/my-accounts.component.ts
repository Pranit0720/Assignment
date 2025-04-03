import { Component, ElementRef, OnInit } from '@angular/core';
import { Accounts } from '../../model/accounts';
import { AccountService } from '../../services/account.service';
import { CommonModule } from '@angular/common';
import { AccountEnumString } from '../../constants';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-my-accounts',
  standalone: true,
  imports: [CommonModule,RouterModule],
  templateUrl: './my-accounts.component.html',
  styleUrl: './my-accounts.component.css',
})
export class MyAccountsComponent implements OnInit {
  

  accounts: Accounts[] = [];
  allTypes = AccountEnumString;
  constructor(private accountService: AccountService,private router:Router) {}
  ngOnInit() {
    this.getAccount();
  }
  getAccount() {
    this.accountService.getAccounts().subscribe((data) => {
      console.log({ data });
      this.accounts = data;
      console.log(this.accounts);
    });
  }
  onItemSelector(id:number){
    this.accountService.getId(id);
    // console.log(id);
    this.router.navigate(['history']);

  }
  doTransaction(id:number){
    this.accountService.getId(id);
    // console.log(id);
    this.router.navigate(['transaction']);

  }
  transferTransaction(id:number){
    this.accountService.getId(id);
    // console.log(id);
    this.router.navigate(['transferAmount']);

  }deleteAccount(id: number) {
    if (confirm('Are you sure you want to delete this account?')) {
      this.accountService.deleteAccount(id).subscribe(() => {
        this.accounts = this.accounts.filter(account => account.id !== id);
      });
    }
  }

  

  
}

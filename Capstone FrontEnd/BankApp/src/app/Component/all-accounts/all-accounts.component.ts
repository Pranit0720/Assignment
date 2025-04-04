import { Component } from '@angular/core';
import { AccountEnumString } from '../../constants';
import { Accounts } from '../../model/accounts';
import { AccountService } from '../../services/account.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-all-accounts',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './all-accounts.component.html',
  styleUrl: './all-accounts.component.css',
})
export class AllAccountsComponent {
  accounts: Accounts[] = [];
  allTypes = AccountEnumString;
  constructor(private accountService: AccountService, private router: Router) {}
  ngOnInit() {
    this.allAccount();
  }
  allAccount() {
    this.accountService.allAccounts().subscribe((data) => {
      console.log({ data });
      this.accounts = data;
      console.log(this.accounts);
    });
  }

  disableaccount(id: number) {
    // if (id == 1) {
      // if (confirm('Are you sure you want to disable this account?')) {
        this.accountService.softDelete(id).subscribe((data) => {
          console.log({ data });
          this.accounts = data;
          console.log(this.accounts);
          this.allAccount();
        });
      // }
    // }else{
      // if (confirm('Are you sure you want to enable this account?')) {
        // this.accountService.softDelete(id).subscribe((data) => {
        //   console.log({ data });
        //   this.accounts = data;
        //   console.log(this.accounts);
        //   this.allAccount();
        // });
      // }
    // }

  }
}

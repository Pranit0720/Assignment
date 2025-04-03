import { Component } from '@angular/core';
import { Transactions } from '../../model/accounts';
import { TransactionEnumString } from '../../constants';
import { AccountService } from '../../services/account.service';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-history',
  standalone: true,
  imports: [CommonModule,RouterModule],
  templateUrl: './history.component.html',
  styleUrl: './history.component.css'
})
export class HistoryComponent {
  tType=TransactionEnumString;
  // constructor(private )
  transaction: Transactions[] = [];

  constructor(private accountService: AccountService) {

  }
  ngOnInit() {
    this.gettran();
  }
  
  gettran() {
    this.accountService.getTransactions().subscribe((data) => {
      console.log({ data });
      this.transaction = data;
      console.log(this.transaction);
    });
  }

}

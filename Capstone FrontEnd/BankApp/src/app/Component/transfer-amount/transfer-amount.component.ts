import { Component } from '@angular/core';
import { TransferModel } from '../../model/accounts';
import { Router, RouterModule } from '@angular/router';
import { AccountService } from '../../services/account.service';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';

@Component({
  selector: 'app-transfer-amount',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './transfer-amount.component.html',
  styleUrl: './transfer-amount.component.css',
})
export class TransferAmountComponent {
  transferModel: TransferModel = new TransferModel(0, 0);
  errorMessage = '';

  constructor(private router: Router, private accountService: AccountService) {}
  ngonInit() {}

  transfertoanotheruser(transactionForm: NgForm) {
    this.transferModel = transactionForm.value;
    console.log(this.transferModel);
    this.accountService.transferAmount(this.transferModel).subscribe({
      next: (res: TransferModel) => {
        console.log('Transaction Completed', res);
        alert('Transaction Completed');
        transactionForm.reset();
        this.router.navigate(['myAccounts']);
      },
      error: (error) => {
        console.error('registration failed!!', error);
        this.errorMessage = JSON.stringify(error.error);
        alert(this.errorMessage);
      },
    });
  }
}

//     transactionUser(transactionForm:NgForm){
//       this.transactionModel=transactionForm.value;
//     console.log(this.transactionModel);
//     this.accountService.doTransaction(this.transactionModel).subscribe({

//       next:(res:TransactionAddModel)=>{
//         console.log('Transaction Completed',res);
//         alert('Transaction Completed');
//         transactionForm.reset();
//         this.router.navigate(['myAccounts']);
//       },
//       error:(error)=>{
//                 console.error('registration failed!!',error);
//                 this.errorMessage=JSON.stringify(error.error)
//                   alert(this.errorMessage);

//               }

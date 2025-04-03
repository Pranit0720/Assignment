import { Component, NgModule } from '@angular/core';
import { AccountService } from '../../services/account.service';
import { TransactionAddModel, Transactions } from '../../model/accounts';
import { Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';

@Component({
  selector: 'app-transaction',
  standalone: true,
  imports: [CommonModule,FormsModule,RouterModule],
  templateUrl: './transaction.component.html',
  styleUrl: './transaction.component.css',
})
export class TransactionComponent {
  transactionModel:TransactionAddModel= new TransactionAddModel(0,'');
  errorMessage="";
  
  constructor(private router:Router,private accountService: AccountService) {}
    ngonInit() {

    }

    transactionUser(transactionForm:NgForm){
      this.transactionModel=transactionForm.value;
    console.log(this.transactionModel);
    this.accountService.doTransaction(this.transactionModel).subscribe({

      next:(res:TransactionAddModel)=>{
        console.log('Transaction Completed',res);
        alert('Transaction Completed');
        transactionForm.reset();
        this.router.navigate(['myAccounts']);
      },
      error:(error)=>{
                console.error('registration failed!!',error);
                this.errorMessage=JSON.stringify(error.error)
                  alert(this.errorMessage);

              }
    })

   


    }
 
}
 


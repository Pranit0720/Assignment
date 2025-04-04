import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Accounts, AddAccount, TransactionAddModel, Transactions, TransferModel } from '../model/accounts';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private uid=localStorage.getItem('UserId');
  sharedData!: number;
  constructor(private http:HttpClient) { }
  getAccounts():Observable<Accounts[]>{
    // const headers = new HttpHeaders({
    //   'Authorization': `Bearer ${localStorage.getItem("token")}`
    // });
    // return this.http.get<Accounts[]>(`https://localhost:7092/api/Account/GetAllAccounts`);
    return this.http.get<Accounts[]>(`https://localhost:7092/api/Account/MyAccounts`);
  }

  getTransactions():Observable<Transactions[]>{
    return this.http.get<Transactions[]>(`https://localhost:7092/api/Transaction/GetByAccountId?accountId=${this.sharedData}`)
  }

  doTransaction(transactionData:TransactionAddModel):Observable<TransactionAddModel>{
      return this.http.post<TransactionAddModel>(`https://localhost:7092/api/Transaction?id=${this.sharedData}`,transactionData);
  }
  transferAmount(transactionData:TransferModel):Observable<TransferModel>{
    return this.http.post<TransferModel>(`https://localhost:7092/api/Transaction/Transfer?id=${this.sharedData}`,transactionData);
}
AddAccount(transactionData:any):Observable<any>{
  return this.http.post(`https://localhost:7092/api/Account/AddAccount`,transactionData);
}
deleteAccount(id: number): Observable<any> {
  return this.http.delete(`https://localhost:7092/api/Account/${id}`);
}
allAccounts(): Observable<Accounts[]> {
  return this.http.get<Accounts[]>(`https://localhost:7092/api/Account/GetAllAccounts`);
}

softDelete(id:number):Observable<any>{
  return this.http.put(`https://localhost:7092/api/Account/DisableAccount?accountId=${id}`,id);
}

  getId(id:number){
    this.sharedData=id;
    // console.log(id);
  }
}

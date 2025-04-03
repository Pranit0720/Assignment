import { Component } from '@angular/core';
import { Routes } from '@angular/router';
import { RegisterComponent } from './Component/Register/register.component';
import { LoginComponent } from './Component/login/login.component';
import { DashBoardComponent } from './Component/dash-board/dash-board.component';
import { MyAccountsComponent } from './Component/my-accounts/my-accounts.component';
import { HistoryComponent } from './Component/history/history.component';
import { TransactionComponent } from './Component/transaction/transaction.component';
import { TransferAmountComponent } from './Component/transfer-amount/transfer-amount.component';
import { AddAccountComponent } from './Component/add-account/add-account.component';

export const routes: Routes = [
    {path:'register',component:RegisterComponent},
    {path:'login',component:LoginComponent},
    {path:'dashboard',component:DashBoardComponent},
    {path:'myAccounts',component:MyAccountsComponent},
    {path:'history',component:HistoryComponent},
    {path:'transaction',component:TransactionComponent},
    {path:'transferAmount',component:TransferAmountComponent},
    {path:'AddAccount',component:AddAccountComponent},



];

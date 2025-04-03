import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { LoginComponent } from './Component/login/login.component';
import { DashBoardComponent } from './Component/dash-board/dash-board.component';
import { HeaderComponent } from './Component/header/header.component';
import { RegisterComponent } from './Component/Register/register.component';
import { MyAccountsComponent } from './Component/my-accounts/my-accounts.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,LoginComponent,DashBoardComponent,HeaderComponent,RegisterComponent,MyAccountsComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'BankApp';
}

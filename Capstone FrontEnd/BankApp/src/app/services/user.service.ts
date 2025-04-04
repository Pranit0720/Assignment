import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
// import { Observable } from 'rxjs';
import { Login, LoginResposnceModel } from '../model/login';
import { Observable } from 'rxjs/internal/Observable';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
// https://localhost:7092/api/Auth/login
// https://localhost:7092/api/Account/GetAllAccounts
export class UserService {

  
  private apiUrl="https://localhost:7092/api/Auth"
 
  constructor(private http:HttpClient) { }
  login(loginData:Login):Observable<LoginResposnceModel>{
    return this.http.post<LoginResposnceModel>(`${this.apiUrl}/login`,loginData )
  }
  
  isLoggedIn():boolean{
      return !!localStorage.getItem('token');
  }
}

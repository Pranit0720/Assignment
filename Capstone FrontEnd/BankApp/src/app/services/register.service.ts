import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Register, registerResponceModel } from '../model/register';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  private apiUrl="https://localhost:7092/api/Auth"
  constructor(private http:HttpClient) { }

  register(registerData:Register):Observable<registerResponceModel>{
    return this.http.post<registerResponceModel>(`${this.apiUrl}/register`,registerData);
  }

  
}

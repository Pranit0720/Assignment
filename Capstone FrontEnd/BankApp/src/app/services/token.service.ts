import { Injectable } from '@angular/core';
import {jwtDecode} from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class TokenService {

  userRole: string | null = null;
 
  ngOnInit(){
    console.log(this.getUserRole())
  }
 
  getToken(): string | null {
    return localStorage.getItem('token');
  }
 
  getUserRole(): string | null {
    const tokenstring = this.getToken();
    if (!tokenstring) {
      return null;
    }
   
    try {
      const decodedToken: any = jwtDecode(tokenstring);
      return decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] || null;
    } catch (error) {
      console.error('Invalid token:', error);
      return null;
    }
  }
 
  isAdmin(): boolean {
    const role = this.getUserRole();
    console.log("User Role:", role); 
    return role === 'Administartor';
  }
  isUser(): boolean {
    console.log(this.userRole );
    const role = this.getUserRole();

    return this.userRole == 'User';
  }
}

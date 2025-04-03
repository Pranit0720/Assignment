import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { Login, LoginResposnceModel } from '../../model/login';
import { UserService } from '../../services/user.service';
import { RouterService } from '../../services/router.service';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule,RouterModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  // login(_ts: NgForm) {
  //   console.log(_ts.value);
  // }

  loginModel: Login = new Login('', '');
  errorMessage='';

  constructor(private router:Router,private userService: UserService) {}
  ngonInit() {
    // this.loginUser();
  }
  // loginUser() {
  //   this.loginModel.email = 'sumit@gmail.com';
  //   this.loginModel.password = 'Sumit@123';
  //   this.userService.login(this.loginModel).subscribe((res) => {
  //     console.log(res);
  //   });
  // }

  loginUser(loginForm:NgForm){
    this.loginModel=loginForm.value;
    console.log(this.loginModel);
    this.userService.login(this.loginModel).subscribe({
      next:(response:LoginResposnceModel)=>{

        console.log('Login Success',response);
        localStorage.setItem('token',response.token);
        localStorage.setItem('email',response.email);
        window.dispatchEvent(new Event("storage")); 

        
        alert('LoginSuccess');
        loginForm.reset();
        this.router.navigate(['dashboard']);
      },
      error:(error)=>{

        console.error('loginFailed',error);
        this.errorMessage=JSON.stringify(error.error)
        alert(this.errorMessage);
        // this.errorMessage="Invalid email or password";
        
      }
        

        
    })

  }
}

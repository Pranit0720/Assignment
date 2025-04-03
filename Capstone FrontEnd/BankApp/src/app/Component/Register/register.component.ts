import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { Register, registerResponceModel } from '../../model/register';
import { RegisterService } from '../../services/register.service';
import { response } from 'express';
import { error } from 'console';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule,CommonModule,RouterModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  registerModel:Register=new Register('','','','');
  errorMessage='';
  

  constructor(private router:Router,private registerService: RegisterService) {}
    ngonInit() {
      
    }
  registerUser(registerForm:NgForm) {
    this.registerModel=registerForm.value;
    console.log({reg: this.registerModel});

    this.registerService.register(this.registerModel).subscribe({

      next:(response:registerResponceModel)=>{
        console.log('register Success',response);
        localStorage.setItem('UserId',response.userId);
        registerForm.reset();
        this.router.navigate(['login']);
      },
      error:(error)=>{
        console.error('registration failed!!',error);
        this.errorMessage=JSON.stringify(error.error)
          alert(this.errorMessage);
      }
      
        
      })
      
    
    }
  }






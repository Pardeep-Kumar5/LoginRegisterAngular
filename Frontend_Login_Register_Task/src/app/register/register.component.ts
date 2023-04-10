import { RegisterService } from './../register.service';
import { Component } from '@angular/core';
import { Register } from '../register';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  registerErrorMsg:string="";
  newregister:Register= new Register();
  constructor(private registerService:RegisterService){} 
  registerclick()
  {
    this.registerService.Register(this.newregister).subscribe(
      (Response)=>{
       
        this.newregister.username="";
        this.newregister.password="";
        this.newregister.confirmPassword="";
   
      },
      (Error)=>{
        console.log(Error);
        this.registerErrorMsg= "The password and confirmation password do not match."
      }
    );
  }  
  loginWithGoogle()
  {
    window.open('https://localhost:44333/api/Register/ExternalLoginCallback', '_self');
  }
}

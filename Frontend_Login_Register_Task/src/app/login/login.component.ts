import { Component } from '@angular/core';
import { Login } from '../login';
import { LoginService } from '../login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})

export class LoginComponent {
  
  login: Login = new Login();
  loginErrorMsg:string="";
  constructor(private loginservice: LoginService, private router: Router) { }

  logincheck() {
    //alert(this.login.username)
    this.loginservice.checkuser(this.login).subscribe(
      (Responce) => {
        this.router.navigateByUrl("/employee");
      },
      (Error) => {
        console.log(Error);
        //alert('wrong User/PWd');
    this.loginErrorMsg="Wrong User/ Password"

      }
    );
  }

}
